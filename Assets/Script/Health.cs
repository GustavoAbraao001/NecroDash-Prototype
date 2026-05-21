using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Health : MonoBehaviour
{

    [Header("Configurações de Vida")]
    [SerializeField] private int vidaMaxima = 5;
    private int vidaAtual;

    [Header("Interface do usuário")]
    [SerializeField] private TextMeshProUGUI textoVida;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarInterface();
    }

    public void TomarDano(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;

        AtualizarInterface();

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    private void AtualizarInterface()
    {
        if (textoVida != null)
        {
            textoVida.text = "Vida: " + vidaAtual;
        }

        
    }
    private void Morrer()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("GameOver");
    }

}
