using UnityEngine;

public class Palanca : MonoBehaviour
{
    public Transform player1; // Asignar el transform del primer jugador
    public Transform player2; // Asignar el transform del segundo jugador
    public float activationDistance = 1.0f; // Distancia a la que los jugadores pueden activar la palanca
    private bool isActivated = false; // Controla si la palanca ya fue activada

    void Update()
    {
        // Verifica la distancia de ambos jugadores
        if (!isActivated && (Vector2.Distance(player1.position, transform.position) <= activationDistance || Vector2.Distance(player2.position, transform.position) <= activationDistance))
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                ActivateLever();
            }
        }
    }

    private void ActivateLever()
    {
        isActivated = true;

        // Encuentra todas las cajas y añade un Rigidbody2D si no tienen uno
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("caja");
        foreach (GameObject box in boxes)
        {
            Rigidbody2D rb = box.GetComponent<Rigidbody2D>();
            if (rb == null)  // Si no hay Rigidbody2D, añade uno
            {
                rb = box.AddComponent<Rigidbody2D>();
                rb.gravityScale = 1;  // Ajusta según necesidad
                                      // Configura otras propiedades del Rigidbody2D según sea necesario
            }
        }
    }

}
