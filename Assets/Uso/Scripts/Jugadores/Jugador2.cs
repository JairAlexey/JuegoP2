using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador2 : MonoBehaviour
{
    public float JumpForce;
    public float Speed;

    private Animator animator;
    private Rigidbody2D rb2d;
    private bool Grounded;

    [SerializeField] private ParticleSystem particulas;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {

        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.Keypad4))
        {
            horizontalInput = -0.6156f;
            particulas.Play();
        }
        else if (Input.GetKey(KeyCode.Keypad6))
        {
            horizontalInput = 0.6156f;
            particulas.Play();
        }


        // Actualiza la animación y la escala del jugador en función del movimiento horizontal
        if (horizontalInput != 0)
        {
            animator.SetBool("Running", true);  // Establece la animación de correr como verdadera en el Animator
            transform.localScale = new Vector3(horizontalInput, 0.6156f, 0.6156f);  // Voltea la escala del jugador según la dirección horizontal
        }
        else
        {
            animator.SetBool("Running", false);  // Establece la animación de correr como falsa en el Animator
        }


        // Dibuja un rayo desde la posición del jugador hacia abajo para detectar si está en el suelo
        bool wasGrounded = Grounded;  // Almacena el estado previo de "Grounded"
        Debug.DrawRay(transform.position, Vector3.down * 0.4f, Color.red);  // Dibuja el rayo en la escena
        Grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.4f);

        if (Grounded)
        {
            if (wasGrounded == false)
            {
                animator.SetBool("Jump", false);  // Establece la animación de salto como falsa en el Animator
            }
        }
        else
        {
            if (wasGrounded)
            {
                animator.SetBool("Jump", true);  // Establece la animación de salto como verdadera en el Animator
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && Grounded)
        {
            Jump();
        }

    }

    private void Jump()
    {
        rb2d.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.Keypad4)) horizontalInput = -0.6156f;
        else if (Input.GetKey(KeyCode.Keypad6)) horizontalInput = 0.6156f;

        rb2d.velocity = new Vector2(horizontalInput * Speed, rb2d.velocity.y);
    }

}
