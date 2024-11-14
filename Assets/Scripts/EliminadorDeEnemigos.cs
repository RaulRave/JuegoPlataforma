using UnityEngine;

public class EliminadorDeEnemigos : MonoBehaviour
{
    public float tiempoDestruccion = 2f; // Tiempo antes de destruir el objeto
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemigo"))
            
        {
            collision.gameObject.SetActive(false);

            Destroy(collision.gameObject, tiempoDestruccion);
        }
    }
}
