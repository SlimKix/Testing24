using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;

    [SerializeField]
    float movementSpeed = 5f;
    [SerializeField]
    float jumpForce = 5f;

    bool isGrounded;

    Vector2 movementDirection;
    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        handleInput();

    }

    private void FixedUpdate()
    {
        Movement();
        Rotation();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    void Movement()
    {
        rb.velocity = new Vector3(movementDirection.x * movementSpeed, rb.velocity.y, movementDirection.y * movementSpeed);
    }
    void Rotation() 
    {
       transform.rotation = Quaternion.Euler(1 * 5, rb.rotation.y, rb.rotation.z);

    }

    void handleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("HorizontalR");
        movementDirection = new Vector2(horizontalInput, verticalInput);

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }
    }
}
