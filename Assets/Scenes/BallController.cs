using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody sphereRigidbody;
    
    [Header("Movement Settings")]
    public float moveForce = 500f;
    public float turnForce = 300f;
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
            // Updated here
            sphereRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
    
    
    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");
        
        Vector3 movement = transform.forward * forwardInput;
        
        // Updated here
        sphereRigidbody.AddForce(movement * moveForce * Time.fixedDeltaTime);
        
        // And here
        sphereRigidbody.AddTorque(Vector3.up * turnInput * turnForce * Time.fixedDeltaTime);
    }
}
