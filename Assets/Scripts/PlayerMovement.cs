using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 5f;
    public float airSpeed = 4f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the player is on the ground or not
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If the player is on the ground and they're not falling or jumping, then set their velocity on the Y axis to be -2 (Should be 0, but I've been told that -2 just works better) 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Gets the players input from mouse movements
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Sets a movement variable to be where the player is moving towards (X and Z value)
        Vector3 move = transform.right * x + transform.forward * z;

        // Moves the player towards those coordinates (X and Z)
        if (velocity.y != -2)
        {
            controller.Move(move * airSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        // If the player is grounded and presses the jump button, then have the player jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Sets the players Y velocity based on gravity
        velocity.y += gravity * Time.deltaTime;

        // Moves the player according to their velocities
        controller.Move(velocity * Time.deltaTime);
    }
}
