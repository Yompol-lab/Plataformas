using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathZone : MonoBehaviour
{
    public float deathY = -10f;

    void Update()
    {
        if (transform.position.y < deathY)
        {
            SceneManager.LoadScene("Moriste");
        }
    }
}
