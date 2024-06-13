using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    public Transform player; // El jugador que la c�mara seguir�
    public Vector3 offset; // La distancia entre la c�mara y el jugador

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
