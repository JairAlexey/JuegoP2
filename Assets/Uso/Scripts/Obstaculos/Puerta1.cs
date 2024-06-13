using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisionó tiene la etiqueta "Player1" o "Player2"
        if (other.CompareTag("Player"))
        {
            // Cambia a la escena a la pantalla de ganadores
            SceneManager.LoadScene("WinnersScene");
        }
    }
}
