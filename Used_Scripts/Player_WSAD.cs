using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WSAD : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Player_Physics playerPhysics;
    private Player_Animator playerAnimator;

    private float normalSpeed; // przechowuje normalną prędkość

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPhysics = GetComponent<Player_Physics>();
        playerAnimator = GetComponent<Player_Animator>();
        normalSpeed = speed; // przypisanie normalnej prędkości przy starcie
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            moveHorizontal = touchDeltaPosition.x;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime);

        // Wywołanie funkcji skoku z PlayerPhysics
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerPhysics.Jump();
        }

        // Wywołanie funkcji ustawiającej prędkość z PlayerAnimator
        playerAnimator.SetSpeed(moveHorizontal);
    }

    // Funkcja do zmiany prędkości
    public void ChangeSpeed(float newSpeed)
    {
        speed = 6F;
    }

    // Funkcja do przywrócenia normalnej prędkości
    public void ResetSpeed()
    {
        speed = normalSpeed;
    }
}
