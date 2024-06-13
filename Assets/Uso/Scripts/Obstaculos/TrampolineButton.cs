using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public static bool isPresionado1 = false; // Asegúrate de que estas variables sean accesibles globalmente o compartidas adecuadamente
    public static bool isPresionado2 = false;
    public GameObject particulas;
    public GameObject aire;

    private void Update()
    {
        // Verificar ambos botones en cada frame para debug
        CheckBothPressed();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (gameObject.name == "Boton1" && collision.collider.CompareTag("Player"))
        {
            isPresionado1 = true;
        }
        else if (gameObject.name == "Boton2" && collision.collider.CompareTag("Player"))
        {
            isPresionado2 = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.name == "Boton1" && collision.collider.CompareTag("Player"))
        {
            isPresionado1 = false;
        }
        else if (gameObject.name == "Boton2" && collision.collider.CompareTag("Player"))
        {
            isPresionado2 = false;
        }
    }

    private void CheckBothPressed()
    {
        if (isPresionado1 && isPresionado2)
        {
            particulas.SetActive(false);
            aire.SetActive(false);
        }
    }
}
