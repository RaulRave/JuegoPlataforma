using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject[] fondos; // Array de GameObjects que contienen los fondos y duplicados
    public float[] velocidadFondos; // Array de velocidades de los fondos
    public float[] tamaños; // Array de tamaños de los fondos
    public GameObject fondoEstatico; // Fondo que debe seguir la cámara

    private Camera mainCamera;
    private Vector3 previousCameraPosition;

    void Start()
    {
        mainCamera = Camera.main;
        previousCameraPosition = mainCamera.transform.position;
    }

    void Update()
    {
        MueveFondos();
        SigueCamaraFondoEstatico(fondoEstatico);
    }

    private void MueveFondos()
    {
        for (int i = 0; i < fondos.Length; i++)
        {
            float offset = velocidadFondos[i] * Time.deltaTime;
            foreach (Transform fondo in fondos[i].transform)
            {
                fondo.Translate(Vector3.left * offset);

                // Reposicionar inmediatamente cuando salga de la vista
                if (fondo.localPosition.x <= -tamaños[i])
                {
                    fondo.localPosition += new Vector3(tamaños[i] * 2, 0, 0);
                }
            }
        }
    }

    private void SigueCamaraFondoEstatico(GameObject fondoEstatico)
    {
        Vector3 deltaMovement = mainCamera.transform.position - previousCameraPosition;
        fondoEstatico.transform.position += deltaMovement;
        previousCameraPosition = mainCamera.transform.position;
    }
}
