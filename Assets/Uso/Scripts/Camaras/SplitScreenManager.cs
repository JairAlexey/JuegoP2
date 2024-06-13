using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenManager : MonoBehaviour
{
    public Camera cameraPlayer1;
    public Camera cameraPlayer2;
    public Camera mainCamera;
    public Transform player1;
    public Transform player2;
    public float distanceThreshold = 5f; // Distancia a la que las cámaras se combinan
    public Vector3 offset = new Vector3(0, 0, -10); // Offset para la cámara principal

    void Update()
    {
        float distance = Vector3.Distance(player1.position, player2.position);

        if (distance < distanceThreshold)
        {
            // Combinar cámaras
            mainCamera.gameObject.SetActive(true);
            cameraPlayer1.gameObject.SetActive(false);
            cameraPlayer2.gameObject.SetActive(false);

            // Posicionar la cámara principal entre los dos jugadores
            Vector3 middlePoint = (player1.position + player2.position) / 2;
            mainCamera.transform.position = middlePoint + offset;
        }
        else
        {
            // Dividir cámaras
            mainCamera.gameObject.SetActive(false);
            cameraPlayer1.gameObject.SetActive(true);
            cameraPlayer2.gameObject.SetActive(true);
        }
    }
}
