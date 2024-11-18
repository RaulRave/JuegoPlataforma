using UnityEngine;

public class GeneradorEnemigosSimple : MonoBehaviour
{
    public GameObject enemigoPrefab; // Prefab del enemigo
    public float intervaloGeneracion = 5f; // Intervalo en segundos entre cada intento de generación de enemigo
    private float tiempoRestante; // Contador para el tiempo restante

    // Rango de generación en el eje Y
    public float minY;
    public float maxY;

    // Referencia a la cámara
    public Transform camaraTransform;

    // Límite derecho en el eje X
    public float limiteDerecho = 9.43f;

    // Probabilidad de generar un enemigo (valor entre 0 y 100)
    public float probabilidadGeneracion = 50.0f;

    void Start()
    {
        if (camaraTransform == null)
        {
           // Debug.LogError("Referencia a la cámara no asignada en el Inspector");
            return;
        }

        if (enemigoPrefab == null)
        {
            //Debug.LogError("Prefab del enemigo no asignado en el Inspector");
            return;
        }

        tiempoRestante = intervaloGeneracion; // Inicializar el contador con el intervalo de generación
    }

    void Update()
    {
        if (camaraTransform == null || enemigoPrefab == null) return;

        tiempoRestante -= Time.deltaTime; // Reducir el contador en cada frame

        if (tiempoRestante <= 0f)
        {
            GenerarEnemigo(); // Intentar generar un enemigo
            tiempoRestante = intervaloGeneracion; // Reiniciar el contador
        }
    }

    private void GenerarEnemigo()
    {
        float random = Random.Range(0.0f, 100.0f); // Genera un número aleatorio entre 0 y 100

        // Debug.Log("Generando enemigo, número aleatorio: " + random);

        if (random < probabilidadGeneracion) // Probabilidad ajustable de instanciar un enemigo
        {
            float posX = camaraTransform.position.x + limiteDerecho; // Posición X exactamente en el límite derecho de la cámara
            float posY = Random.Range(minY, maxY); // Posición Y aleatoria dentro del rango
            Vector2 posicionGeneracion = new Vector2(posX, posY); // Crear el vector de posición

            Instantiate(enemigoPrefab, posicionGeneracion, Quaternion.identity); // Instanciar el enemigo en la posición generada

            // Debug.Log("Enemigo generado en posición: " + posicionGeneracion); // Mensaje de depuración
        }
        else
        {
            // Debug.Log("No se generó enemigo (random >= " + probabilidadGeneracion + ")");
        }
    }
}
