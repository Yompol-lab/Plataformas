using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    public void Jugar() 
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    public void VolverJugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu2");
    }

}
