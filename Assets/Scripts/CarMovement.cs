using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5000.0f;
    private bool isMovingForward = true;


    // Update is called once per frame
    void Update()
    {
        if (isMovingForward)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        //else
        //{
        //    // Calculate the direction towards the player
        //    Vector3 direction = player.position - transform.position;
        //    direction.Normalize();

        //    // Move the car towards the player
        //    transform.position += direction * speed * Time.deltaTime;
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the car has collided with the player
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 forceDirection = transform.position - collision.transform.position;
            forceDirection.y = 1;  // Add upward force
            rb.AddForce(forceDirection.normalized * 500f);
        }
    }
}
