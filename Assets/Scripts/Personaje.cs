using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 500f;
    public int life = 3;
    public float tiempoDestruccion = 1f;
    public int monedas = 0;

    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        bool IsRunning = false;

        // Movimiento a la izquierda
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f));
            IsRunning = true;
        }

        // Movimiento a la derecha
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f));
            IsRunning = true;
        }

        // Actualizar el estado de las animaciones de movimiento
        animator.SetBool("IsRunning", IsRunning);

        // Salto
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false); // Dejar de saltar cuando toca el suelo
        }

        if (collision.collider.CompareTag("Enemigo"))
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, tiempoDestruccion);

            life--;
            Debug.Log("Vidas: " + life);

            if (life <= 0)
            {
                Debug.Log("El Jugador ha muerto");
                gameObject.SetActive(false);

                int recordUltimo = PlayerPrefs.GetInt("Monedas");

                if (!PlayerPrefs.HasKey("Monedas"))
                {
                    PlayerPrefs.SetInt("Monedas", monedas);
                    Debug.Log("Nueva mejor puntuación! Récord: " + monedas);
                }
                else
                {
                    if (recordUltimo < monedas)
                    {
                        PlayerPrefs.SetInt("Monedas", monedas);
                        Debug.Log("Nueva mejor puntuación! Récord: " + monedas);
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moneda"))
        {
            collision.gameObject.SetActive(false);
            monedas++;
            Debug.Log("Monedas: " + monedas);
        }
    }
}






