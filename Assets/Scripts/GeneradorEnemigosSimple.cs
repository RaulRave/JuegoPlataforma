using UnityEngine;

public class GeneradorEnemigosSimple : MonoBehaviour
{
    public GameObject enemigoPrefab; // Prefab del enemigo
    public float intervaloGeneracion = 5f; // Intervalo en segundos entre cada intento de generación de enemigo
    private float tiempoRestante; // Contador para el tiempo restante

    // Rango de generación
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        tiempoRestante = intervaloGeneracion; // Inicializar el contador con el intervalo de generación
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime; // Reducir el contador en cada frame

        if (tiempoRestante <= 0f)
        {
            DecideSiEnemigo(); // Intentar generar un enemigo
            tiempoRestante = intervaloGeneracion; // Reiniciar el contador
        }
    }

    private void DecideSiEnemigo()
    {
        float random = Random.Range(0.0f, 100.0f); // Genera un número aleatorio entre 0 y 100

        if (random < 50.0f) // 1% de probabilidad de instanciar un enemigo
        {
            float posX = Random.Range(minX, maxX); // Posición X aleatoria dentro del rango
            float posY = Random.Range(minY, maxY); // Posición Y aleatoria dentro del rango
            Vector2 posicionGeneracion = new Vector2(posX, posY); // Crear el vector de posición

            Instantiate(enemigoPrefab, posicionGeneracion, Quaternion.identity); // Instanciar el enemigo en la posición generada

            Debug.Log("Enemigo generado en posición: " + posicionGeneracion); // Mensaje de depuración
        }
    }
}
