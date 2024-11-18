using UnityEngine;

public class EliminadorDeEnemigos : MonoBehaviour
{
    public float tiempoDestruccion = 2f; // Tiempo antes de destruir el objeto
    public Transform camaraTransform; // Referencia a la cámara

    void Start()
    {
        if (camaraTransform == null)
        {
            Debug.LogError("Referencia a la cámara no asignada en el Inspector");
        }
    }

    void Update()
    {
        if (camaraTransform != null)
        {
            // Mover el eliminador de enemigos a la posición de la cámara
            transform.position = new Vector3(camaraTransform.position.x, transform.position.y, transform.position.z);
        }
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
