using UnityEngine;

public class MoverSuelo : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    public float tamSuelo; // Tamaño del suelo

    private Camera mainCamera; // Referencia a la cámara principal

    void Start()
    {
        mainCamera = Camera.main; // Inicializar la referencia a la cámara principal
    }

    void Update()
    {
        if (mainCamera == null)
        {
           // Debug.LogError("Referencia a la cámara principal no asignada");
            return;
        }

        // Mueve el suelo hacia la izquierda
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        // Verifica la distancia entre la cámara y el suelo
        Vector3 distancia = mainCamera.transform.position - transform.position;
        if (distancia.magnitude >= tamSuelo)
        {
            // Reposiciona el suelo a la derecha de la cámara
            transform.position = new Vector3(mainCamera.transform.position.x + tamSuelo, transform.position.y, transform.position.z);
        }
    }
}
