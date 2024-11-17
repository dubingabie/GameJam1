using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody sphereRigidbody;
    
    
    [Header("Movement Settings")]
    public float moveSpeed = 300f;
    public float jumpForce = 300f;
    
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Updated variable name here too
        sphereRigidbody = GetComponent<Rigidbody>();
    }
    
     
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            sphereRigidbody.AddForce(Vector3.up * jumpForce);
        }
        
        // Get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // Create movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        
        // Move using Translate
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
    
}
