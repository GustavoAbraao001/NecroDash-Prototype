using UnityEngine;

public class Projeteis : MonoBehaviour
{
    private Vector3 direcaoMove = Vector3.forward;
    [SerializeField]private float velocidadeBala = 10f;

    public void Inicializar(Vector3 direcao, float velocidade)
    {
        
        if (velocidade > 0)
        {
            this.velocidadeBala = velocidade;
        }

        if(direcaoMove != Vector3.zero)
        {
            transform.forward = direcaoMove;
        }

        Destroy(gameObject, 4f);
    }
 

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * velocidadeBala * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Health sistemaVida = other.GetComponent<Health>();

            if (sistemaVida != null)
            {
                sistemaVida.TomarDano(1);
            }


            Destroy(gameObject);
        }
        else if (other.CompareTag("Parede") )
        {
            Destroy(gameObject);
        }
    }
}
