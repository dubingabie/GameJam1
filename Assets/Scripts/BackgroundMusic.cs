using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip musicClip;
    [SerializeField][Range(0.0f, 3.0f)] private float volume = 1.0f;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.volume = volume;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
