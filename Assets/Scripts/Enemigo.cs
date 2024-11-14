using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento ajustable
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f));
    }
}
