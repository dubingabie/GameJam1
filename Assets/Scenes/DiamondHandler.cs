using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the diamond
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Make sure your ball has "Player" tag
        {
            Destroy(gameObject);
        }
    }
}
