using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI vidas_txt;
    public TextMeshProUGUI manzanas_txt;
    public Personaje pj;

    void Start()
    {
        // Encuentra los objetos TextMeshPro por su nombre en la escena
        vidas_txt = GameObject.Find("vidas_txt").GetComponent<TextMeshProUGUI>();
        manzanas_txt = GameObject.Find("manzanas_txt").GetComponent<TextMeshProUGUI>();

        if (vidas_txt == null || manzanas_txt == null)
        {
            Debug.LogError("No se encontraron los componentes TextMeshProUGUI. Verifica los nombres y la configuración en el Hierarchy.");
            return;
        }

        // Inicializamos los textos con los valores iniciales
        ActualizarUI();
    }

    void Update()
    {
        ActualizarUI();
    }

    void ActualizarUI()
    {
        vidas_txt.text = "Vidas: " + pj.life.ToString();
        manzanas_txt.text = "Manzanas: " + pj.monedas.ToString();
    }
}


