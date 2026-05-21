using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool jogoAcabou = false;

    void Update()
    {
        if (jogoAcabou) return;

        GameObject[] inimigosRestantes = GameObject.FindGameObjectsWithTag("Inimigo");

        if (inimigosRestantes.Length == 0)
        {
            VencerJogo();
        }
    }

    void VencerJogo()
    {
        jogoAcabou = true;
        Debug.Log("Todos os inimigos eliminados! Vitória!");

        
        SceneManager.LoadScene("CenaVitoria");
    }
}

