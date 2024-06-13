using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisionó tiene la etiqueta "Player1" o "Player2"
        if (other.CompareTag("Player"))
        {
            // Cambia a la escena del nivel 2
            SceneManager.LoadScene("Nivel 2");
        }
    }
}
