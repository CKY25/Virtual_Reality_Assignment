using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSound : MonoBehaviour
{
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        // Assuming the AudioSource is on the same GameObject as this script
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
