using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Variables públicas ajustables desde el Inspector de Unity
    public float moveSpeed = 5f; // Velocidad de movimiento ajustable
    public float jumpForce = 500f; // Fuerza de salto ajustable
    public int life = 3;
    public float tiempoDestruccion = 1f;

    // Variables privadas
    private bool isGrounded; // Indica si el personaje está en el suelo
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D del personaje

    // Método Start, se llama una vez al inicio
    void Start()
    {
        // Obtener y asignar el componente Rigidbody2D al principio
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
           
        }
        life = 3;
    }

    // Método Update, se llama una vez por frame
    void Update()
    {
        // Movimiento horizontal
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Mueve el personaje a la izquierda
            transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Mueve el personaje a la derecha
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }

        // Salto
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            // Aplica una fuerza hacia arriba para hacer saltar al personaje
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Evita saltos múltiples en el aire
           
        }
    }

    // Método OnCollisionEnter2D, se llama cuando el personaje colisiona con otro objeto
    void OnCollisionEnter2D(Collision2D collision)
    {
       

        // Verifica si el objeto con el que colisiona tiene el tag "Ground"
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true; // Permite saltar nuevamente
            
        }

        if (collision.collider.CompareTag("Enemigo"))
        {
            collision.gameObject.SetActive(false);

            Destroy(collision.gameObject, tiempoDestruccion);

            life = life - 1;
            Debug.Log("vidas  " + life);

            if (life <= 0)
            {
                Debug.Log("El Jugador ha muerto");
                gameObject.SetActive(false);
            }


        }


    }
}


