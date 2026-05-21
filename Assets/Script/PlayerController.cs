using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuração do Joystick")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;


    [SerializeField] private float speed;

    [Header("Configuração do Dash")]
    [SerializeField] private float dashForce = 25f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private float dashCooldown = 1.0f;

    [Header("Efeitos visuais")]
    [SerializeField] TrailRenderer traileffect;

    public bool isDashing = false;
    private float nextDashTime = 0f;
    private Vector3 lastMoveDirection = Vector3.forward;

    private void Start()
    {
        if (traileffect != null)
        {
            traileffect.emitting = false;
        }
    }
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        if (isDashing) return;

        
        Vector3 direcaoInput = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);

        // 2. Verifica se o jogador está movendo o analógico
        if (direcaoInput.magnitude > 0.1f)
        {
            
            Vector3 direcaoNormalizada = direcaoInput.normalized;

            
            rb.linearVelocity = new Vector3(direcaoNormalizada.x * speed, rb.linearVelocity.y, direcaoNormalizada.z * speed);

            
            
            Vector3 direcaoOlhar = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            if (direcaoOlhar != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direcaoOlhar);
            }
        }
        else
        {
            // Se soltou o analógico, para o boneco imediatamente no chão
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }
    }


    public void RealizarDash()
    {
      if (!isDashing && Time.time >= nextDashTime)
        {
            StartCoroutine(ExecutarDash());
            nextDashTime = Time.time + dashCooldown;
        }  
    }




    private System.Collections.IEnumerator ExecutarDash()
    {
        isDashing = true;
        nextDashTime = Time.time + dashCooldown;

       
        Vector3 direcaoDash = transform.forward;

        if (traileffect != null)
        {
            traileffect.Clear();
            traileffect.emitting = true;
        }

       
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);

        
        rb.AddForce(direcaoDash * dashForce, ForceMode.VelocityChange);

       
        yield return new WaitForSeconds(dashDuration);

       
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);

        if (traileffect != null)
        {
            traileffect.emitting = false;
        }

        isDashing = false;
    }
}

