using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movement = 5f;
    [SerializeField] float jump = 4f;
    [SerializeField] float sprint = 3f;
    [SerializeField] LayerMask ground;


    [SerializeField] Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) && verticalInput > 0)
        {
            rb.velocity = new Vector3(horizontalInput * movement * sprint, rb.velocity.y, verticalInput * movement * sprint);
        }
        else
        {
            rb.velocity = new Vector3(horizontalInput * movement, rb.velocity.y, verticalInput * movement);
        }
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}