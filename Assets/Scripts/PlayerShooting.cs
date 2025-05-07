using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireCooldown = 0.5f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        Vector3 direction = transform.localScale.x > 0 ? Vector3.right : Vector3.left;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction);
        }

       
        Vector3 bulletScale = bullet.transform.localScale;
        bulletScale.x = direction.x > 0 ? Mathf.Abs(bulletScale.x) : -Mathf.Abs(bulletScale.x);
        bullet.transform.localScale = bulletScale;
    }

}
