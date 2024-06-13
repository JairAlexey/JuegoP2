using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator animator;
    public CameraShake cameraShake;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pinchos"))
        {

            StartCoroutine(cameraShake.Shake(0.15f, 0.8f));
            Die();
        }
    }

    void Die()
    {
        // Activar la animaci�n de explosi�n
        animator.SetBool("Dead", true);

        // Desactivar el personaje despu�s de un peque�o retraso para dar tiempo a que se visualice la animaci�n de muerte
        Invoke("DeactivatePlayer", 0.9f);

        // Reinicia la escena despu�s de un peque�o retraso para dar tiempo a que se visualice la animaci�n de muerte
        Invoke("RestartScene", 2f);
    }

    void DeactivatePlayer()
    {
        gameObject.SetActive(false);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
