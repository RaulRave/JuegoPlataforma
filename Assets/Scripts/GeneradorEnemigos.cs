using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject enemigo_Original; // Referencia al prefab de enemigos

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DecideSiEnemigo(); // Llamar al método en cada frame
    }

    private void DecideSiEnemigo()
    {
        float random = Random.Range(0.0f, 100.0f); // Genera un número aleatorio entre 0 y 100

        if (random < 1.0f) // 1% de probabilidad de instanciar un enemigo
        {
            Instantiate(enemigo_Original, transform.position, transform.rotation); // Instancia el prefab en la posición y rotación del generador
        }
    }
}



