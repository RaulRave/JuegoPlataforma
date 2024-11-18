using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    public float velocidadCamara = 5f; // Velocidad de movimiento de la c�mara
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve la c�mara hacia la derecha con la velocidad especificada
        // Time.deltaTime es la cantidad de tiempo que pasó desde la última ejecución de Update
        //transform.Translate(new Vector3(velocidadCamara * Time.deltaTime, 0.0f, 0.0f));
        transform.Translate(new Vector3(velocidadCamara * Time.deltaTime, 0));
    }
}
