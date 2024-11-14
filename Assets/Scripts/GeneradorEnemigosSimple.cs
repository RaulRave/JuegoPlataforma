using UnityEngine;

public class GeneradorEnemigosSimple : MonoBehaviour
{
    public GameObject enemigoPrefab; // Prefab del enemigo
    public float intervaloGeneracion = 5f; // Intervalo en segundos entre cada intento de generaci�n de enemigo
    private float tiempoRestante; // Contador para el tiempo restante

    // Rango de generaci�n
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        tiempoRestante = intervaloGeneracion; // Inicializar el contador con el intervalo de generaci�n
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
        float random = Random.Range(0.0f, 100.0f); // Genera un n�mero aleatorio entre 0 y 100

        if (random < 50.0f) // 1% de probabilidad de instanciar un enemigo
        {
            float posX = Random.Range(minX, maxX); // Posici�n X aleatoria dentro del rango
            float posY = Random.Range(minY, maxY); // Posici�n Y aleatoria dentro del rango
            Vector2 posicionGeneracion = new Vector2(posX, posY); // Crear el vector de posici�n

            Instantiate(enemigoPrefab, posicionGeneracion, Quaternion.identity); // Instanciar el enemigo en la posici�n generada

            Debug.Log("Enemigo generado en posici�n: " + posicionGeneracion); // Mensaje de depuraci�n
        }
    }
}
