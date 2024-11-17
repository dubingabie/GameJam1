using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // Reference to the ball's transform
    
    [Header("Camera Settings")]
    public float distance = 10.0f;     // Distance behind ball
    public float height = 5.0f;        // Height above ball
    public float smoothSpeed = 10.0f;  // How smoothly camera follows
    
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        // Calculate initial offset
        offset = new Vector3(0, height, -distance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void LateUpdate()
    {
        if (target == null) return;
        
        // Calculate desired position
        Vector3 desiredPosition = target.position + offset;
        
        // Smoothly move camera towards desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        
        // Make camera look at ball
        transform.LookAt(target);
    }
}
