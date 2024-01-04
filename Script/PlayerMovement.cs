using UnityEditor.UIElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movement = 5f;
    [SerializeField] float jump = 4f;
    [SerializeField] float sprint = 3f;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform playerCamera; // Tambahkan referensi ke Transform kamera

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

        // Mendapatkan vektor arah gerakan berdasarkan rotasi kamera
        Vector3 forward = playerCamera.forward;
        Vector3 right = playerCamera.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * verticalInput + right * horizontalInput;

        // Mengatur kecepatan bergerak dengan sprint
        float speed = movement;
        if (Input.GetKey(KeyCode.LeftShift) && verticalInput > 0)
        {
            speed *= sprint;
        }

        // Mengatur kecepatan gerakan pemain berdasarkan arah yang dihadapkan oleh kamera
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);

        // Melakukan lompatan jika di tanah
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





// public class PlayerMovement : MonoBehaviour
// {
//     Rigidbody rb;

//     // Showing Selection to Unity
//     [SerializeField] float movement = 5f;
//     [SerializeField] float jump = 4f;
//     [SerializeField] float sprint = 3f;
    
//     [SerializeField] LayerMask ground;
//     [SerializeField] Transform groundCheck;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // Movement
//         float horizontalInput = Input.GetAxis("Horizontal");
//         float verticalInput = Input.GetAxis("Vertical");
        
//         if (Input.GetKey(KeyCode.LeftShift) && verticalInput > 0) // Walk and Run
//         {
//             rb.velocity = new Vector3(horizontalInput * movement * sprint, rb.velocity.y, verticalInput * movement * sprint);
//         }
//         else // Just Walk
//         {
//             rb.velocity = new Vector3(horizontalInput * movement, rb.velocity.y, verticalInput * movement);
//         }
        
//         if (Input.GetButtonDown("Jump") && IsGrounded()) // It's for Jump
//         {
//             rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
//         }
//     }

//     // True or False, When Jump Just Jump Once / Jump when You In The Ground
//     bool IsGrounded()
//     {
//         return Physics.CheckSphere(groundCheck.position, .1f, ground);
//     }
// }
