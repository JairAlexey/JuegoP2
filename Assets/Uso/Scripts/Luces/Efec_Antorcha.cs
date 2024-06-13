using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Efec_Antorcha : MonoBehaviour
{
    public Light2D torchLight; // La luz 2D que va a parpadear
    public float minIntensity = 0.8f; // Intensidad mínima de la luz
    public float maxIntensity = 1.2f; // Intensidad máxima de la luz
    public float flickerSpeed = 0.1f; // Velocidad del parpadeo

    private float randomTime;

    void Start()
    {
        if (torchLight == null)
        {
            torchLight = GetComponent<Light2D>();
        }
        randomTime = Random.Range(0f, 65535f); // Valor aleatorio para el offset de tiempo
    }

    void Update()
    {
        // Calcular una nueva intensidad usando Perlin Noise para suavizar el parpadeo
        float noise = Mathf.PerlinNoise(randomTime, Time.time * flickerSpeed);
        torchLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
