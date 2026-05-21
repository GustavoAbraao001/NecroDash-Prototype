using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public void Jogar()
    {
        
        Time.timeScale = 1f;

        
        SceneManager.LoadScene("CenaJogo");
    }

    
    public void ReiniciarJogo()
    {
        Time.timeScale = 1f; 

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
    public void VoltarParaMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicial"); 
    }

   
    public void SairDoJogo()
    {
        
        Application.Quit();
    }
}

