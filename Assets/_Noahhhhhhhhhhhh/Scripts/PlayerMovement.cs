using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundRayDistance;

    [SerializeField] float fallMultiplier;

    private float horizontal;
    [SerializeField] private bool jump;

    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    

    private void Update()
    {
       

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
            
        }
        else if(Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, groundRayDistance);


        if (jump && isGrounded) 
        {
            Debug.Log("Jump");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (!isGrounded && !jump)
        {
            rb.AddForce(Physics2D.gravity * fallMultiplier);
        }

        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
    }
}
