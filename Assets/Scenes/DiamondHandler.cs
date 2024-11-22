using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiamondHandler : MonoBehaviour
{
    // make header to conrtoll the rotation script
    [Header("Diamond Settings")]

    [SerializeField] private float rotationSpeed = 30.0f;    //rotation speed control variable
    
    [Header("Audio")]
    [SerializeField] private AudioClip collectionSound;
    //add a volume slider to the audio source
    [SerializeField][Range(0.0f, 3.0f)] private float volume = 1.0f;
    private AudioSource audioSource;
    
    //[SerializeField] private  float initialHeight = 0.5f; //initial height of the diamond
    
    // Start is called before the first frame update
    void Start()
    {
  
        //make the cube stand on it's corner 
        transform.rotation = Quaternion.Euler(45f, 45f, 45f); 
        audioSource = gameObject.AddComponent<AudioSource>();

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
            // Play the collection sound if it's not null
            if (collectionSound != null)
            {
                AudioSource.PlayClipAtPoint(collectionSound, transform.position,volume);
            }

            // invoke the add diamond function of score handler
            ScoreManager.Instance.AddDiamond();
            // Destroy the diamond
            Destroy(gameObject);
            

        }
    }
}
