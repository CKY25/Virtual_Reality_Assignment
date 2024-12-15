using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class BGMManager : MonoBehaviour
{

    public AudioSource normalBGM; // Single audio source

    bool isPlaying = false;
    public VideoPlayer Yare;
    public VideoPlayer astronomia;

    void Start()
    {
        // Get the AudioSource component
        normalBGM = GetComponent<AudioSource>();
        normalBGM.Play();
    }

    void Update()
    {
        // Cast rays from the player's position in the forward direction
        RaycastHit hit;

        // Define the ray direction (forward from the game object)
        Vector3 rayDirection = gameObject.transform.TransformDirection(Vector3.forward);

        // Define the ray origin (position of the game object)
        Vector3 rayOrigin = gameObject.transform.position;



        // Define the raycast distance
        float rayDistance = 200000f;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
            if (hit.collider.gameObject.name.Equals("astronomia"))
            {
                // Play YareBGM
                normalBGM.volume = 0;
                astronomia.SetDirectAudioMute(0, false);
                Yare.SetDirectAudioMute(0, true);
                ; Debug.Log("astronomia");
            }

            if (hit.collider.gameObject.name.Equals("Yare"))
            {
                // Play YareBGM
                normalBGM.volume = 0;
                astronomia.SetDirectAudioMute(0, true);
                Yare.SetDirectAudioMute(0, false);
;                Debug.Log("Yare");
            }  
            
            if (hit.collider.gameObject.name.Equals("NormalWallFront")|| hit.collider.gameObject.name.Equals("NormalWallBack"))
            {
                // Play YareBGM
                normalBGM.volume = 1;
                //astronomia.SetDirectAudioMute(0, true);
                //Yare.SetDirectAudioMute(0, true);
;                Debug.Log("wall");
            }


            Debug.DrawRay(rayOrigin, rayDirection * hit.distance, Color.green);
            //Debug.Log("Hit: " + hit.collider.gameObject.name);
        }

    }


}
