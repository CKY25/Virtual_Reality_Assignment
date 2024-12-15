using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.OpenXR;

public class PlayerLost : MonoBehaviour
{
    private bool hasCollided = false;
    private AudioSource audioSource;
    

    void OnTriggerEnter(Collider collision)
    {
        // Check if the collided object is the car and if the collision has not been triggered yet
        if(collision.gameObject.tag == "Car" && !hasCollided)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            Vector3 forceDirection = collision.transform.position - transform.position;
            forceDirection.y = 1;  // Add upward force
            rb.AddForce(forceDirection.normalized * 500f);

            Debug.Log("Collision detected with: " + collision.gameObject.tag);
            //PlayerLosts();
            hasCollided = true;
            // Store the current scene name
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);

            GetComponent<AudioSource>().Play();

            // Transition to the end scene
            StartCoroutine(loadEndScene());
        }
    }

    private IEnumerator loadEndScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EndScene");
    }

   /* void PlayerLosts()
    {
        // Store the current scene name
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);

        // Transition to the end scene
        SceneManager.LoadScene("EndScene");
        Debug.Log("exit");
    }*/
}

