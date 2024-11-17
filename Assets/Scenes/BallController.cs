using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
