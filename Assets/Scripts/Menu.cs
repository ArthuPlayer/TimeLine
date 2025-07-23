using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Jogar()
    {
        SceneManager.LoadScene("EvolucaoHumana");

    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }


}
