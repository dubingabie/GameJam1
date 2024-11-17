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
        // Ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        
        // Jump handling
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            sphereRigidbody.AddForce(Vector3.up * jumpForce);
        }
        
        // Movement handling
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, sphereRigidbody.velocity.y, verticalInput);
        
        // Using velocity instead of AddForce for more responsive movement
        sphereRigidbody.velocity = new Vector3(
            movement.x * moveSpeed * Time.deltaTime, 
            sphereRigidbody.velocity.y, // Keep current vertical velocity (for jumping/falling)
            movement.z * moveSpeed * Time.deltaTime
        );
    }
    
}
