using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    

    private Rigidbody sphereRigidbody;
    
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 300f;
    
    private bool isGrounded;
    
    void Start()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            sphereRigidbody.AddForce(Vector3.up * jumpForce);
        }
        
        // Get input
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");
        //
        // // Create movement vector
        // Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        //
        // // Move using Translate
        // //transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        // sphereRigidbody.AddForce(movement * ( moveSpeed * Time.deltaTime));
        // Move left 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sphereRigidbody.AddForce(Vector3.left * moveSpeed);
        }
        
        // Move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sphereRigidbody.AddForce(Vector3.right * moveSpeed);
        }
        
        // Move forward
        if (Input.GetKey(KeyCode.UpArrow))
        {
            sphereRigidbody.AddForce(Vector3.forward * moveSpeed);
        }
        
        // Move backward
        if (Input.GetKey(KeyCode.DownArrow))
        {
            sphereRigidbody.AddForce(Vector3.back * moveSpeed);
        }
    }
}

