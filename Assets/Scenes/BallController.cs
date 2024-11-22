using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

   
    private Rigidbody sphereRigidbody;
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private float maxSpeed = 10f; // Add this line
    [Header("Audio")]
    [SerializeField] private AudioClip jumpSound;
    private AudioSource audioSource;
    private bool isGrounded;
    
    void Start()
    {   
        audioSource = gameObject.AddComponent<AudioSource>();
        sphereRigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            audioSource.PlayOneShot(jumpSound);
            sphereRigidbody.AddForce(Vector3.up * jumpForce);
        }
        
        // Store current vertical velocity
        float yVelocity = sphereRigidbody.velocity.y;
        
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

        // Limit velocity but preserve vertical speed
        if (sphereRigidbody.velocity.magnitude > maxSpeed)
        {
            Vector3 newVelocity = sphereRigidbody.velocity.normalized * maxSpeed;
            // Restore the original vertical velocity
            newVelocity.y = yVelocity;
            sphereRigidbody.velocity = newVelocity;
        }
    }
}

