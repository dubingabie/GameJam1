using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiamondHandler : MonoBehaviour
{
    // make header to conrtoll the rotation script
    [Header("Diamond Settings")]

    [SerializeField] private float rotationSpeed = 30.0f;    //rotation speed control variable
    
    [SerializeField] private  float initialHeight = 0.5f; //initial height of the diamond
    
    // Start is called before the first frame update
    void Start()
    {
        //make the cube stand on it's corner 
        transform.rotation = Quaternion.Euler(45f, 45f, 45f);
        
        //reset the object it's initial height
        //transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
        //make this green - change this later maybe
        //GetComponent<Renderer>().material.color = Color.green;

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the diamond on the corner 
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f), Space.World);

    }
    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Ball"))  // Make sure your ball has "Player" tag
        {
            // invoke the add diamond function of score handler
            ScoreManager.Instance.AddDiamond();
            // Destroy the diamond
            Destroy(gameObject);

        }
    }
}
