using UnityEngine;

public class Chocolate : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddChocolate();
            Destroy(gameObject);
        }
    }
}
