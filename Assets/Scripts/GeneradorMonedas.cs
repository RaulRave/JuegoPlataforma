using UnityEngine;

public class GeneradorMonedas : MonoBehaviour
{
    public GameObject monedaPrefab; // Prefab de la moneda
    public float intervaloGeneracion = 5f; // Intervalo en segundos entre cada intento de generación de moneda
    private float tiempoRestante; // Contador para el tiempo restante

    // Rango de generación en el eje Y
    public float minY;
    public float maxY;

    // Referencia a la cámara
    public Transform camaraTransform;

    // Límite derecho en el eje X
    public float limiteDerecho = 9.43f;

    // Probabilidad de generar una moneda (valor entre 0 y 100)
    public float probabilidadGeneracion = 50.0f;

    // Velocidad de movimiento de las monedas
    public float velocidadMoneda = 2f;

    void Start()
    {
        if (camaraTransform == null)
        {
            Debug.LogError("Referencia a la cámara no asignada en el Inspector");
            return;
        }

        if (monedaPrefab == null)
        {
            Debug.LogError("Prefab de la moneda no asignado en el Inspector");
            return;
        }

        tiempoRestante = intervaloGeneracion; // Inicializar el contador con el intervalo de generación
    }

    void Update()
    {
        if (camaraTransform == null || monedaPrefab == null) return;

        tiempoRestante -= Time.deltaTime; // Reducir el contador en cada frame

        if (tiempoRestante <= 0f)
        {
            GenerarMoneda(); // Intentar generar una moneda
            tiempoRestante = intervaloGeneracion; // Reiniciar el contador
        }
    }

    private void GenerarMoneda()
    {
        float random = Random.Range(0.0f, 100.0f); // Genera un número aleatorio entre 0 y 100

        if (random < probabilidadGeneracion) // Probabilidad ajustable de instanciar una moneda
        {
            float posX = camaraTransform.position.x + limiteDerecho; // Posición X exactamente en el límite derecho de la cámara
            float posY = Random.Range(minY, maxY); // Posición Y aleatoria dentro del rango
            Vector2 posicionGeneracion = new Vector2(posX, posY); // Crear el vector de posición

            GameObject moneda = Instantiate(monedaPrefab, posicionGeneracion, Quaternion.identity); // Instanciar la moneda en la posición generada
            moneda.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-velocidadMoneda, 0); // Aplicar velocidad a la moneda para que se mueva
        }
    }
}
