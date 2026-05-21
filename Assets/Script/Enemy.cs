using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Configuração de Movimentação")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float velocidadeMovimento = 3f;
    [SerializeField] private float distanciaMinimaAproximacao = 4f;

    [Header("Configurações de Ataque")]
    [SerializeField] private GameObject prefabProjetil;
    [SerializeField] private Transform pontoDisparo;
    [SerializeField] private float tempoEntreTiros = 2.0f;
    [SerializeField] private float velocidadeProjetil = 7f;

    private Transform alvoPlayer;
    private float proximoTempoTiro = 0f;

    private Vector3 direcaoParaPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            alvoPlayer = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alvoPlayer == null) return;

        direcaoParaPlayer = alvoPlayer.position - transform.position;
        direcaoParaPlayer.y = 0f;

        if (direcaoParaPlayer != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direcaoParaPlayer);
        }

        if(Time.time >= proximoTempoTiro)
        {
            Atirar(direcaoParaPlayer);
            proximoTempoTiro = Time.time + tempoEntreTiros;
        }
    }





    private void FixedUpdate()
    {
        if (alvoPlayer == null) return;

        if (rb == null) rb = GetComponent<Rigidbody>();

        float distanciaAtual = Vector3.Distance(transform.position, alvoPlayer.position);

        if (distanciaAtual > distanciaMinimaAproximacao)
        {
            Vector3 direcaoSeguir = direcaoParaPlayer.normalized;
            rb.linearVelocity = new Vector3(direcaoSeguir.x * velocidadeMovimento, rb.linearVelocity.y, direcaoSeguir.z * velocidadeMovimento);
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }


    private void Atirar(Vector3 direcaoTiro)
    {
        if (prefabProjetil == null || pontoDisparo == null) return;

        GameObject balaInstance = Instantiate(prefabProjetil, pontoDisparo.position, pontoDisparo.rotation);

        Projeteis scriptBala = balaInstance.GetComponent<Projeteis>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Inimigo eliminado!");
        }
    }








}
