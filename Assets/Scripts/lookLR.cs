using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookLR : MonoBehaviour
{
    bool canCross = false;
    bool lookedLeft = false;
    bool lookedRight = false;

    public GameObject car;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CrossingZone"))
        {
            canCross = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CrossingZone"))
        {
            canCross = false;
            lookedLeft = false;
            lookedRight = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CrossingZone"))
        {
            canCross = true;
        }
    }

    void Update()
    {
        if (canCross)
        {
            // Cast rays from the player's position in the forward direction
            RaycastHit hit;

            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
                if (hit.collider.gameObject.name.Equals("LeftTrigger"))
                {
                    lookedLeft = true;
                }

                if (hit.collider.gameObject.name.Equals("RightTrigger"))
                {
                    lookedRight = true;
                }
            }

            if (lookedLeft && lookedRight)
            {
                car.GetComponent<CarMovement>().speed = 10;
            }
            else
            {
                car.GetComponent<CarMovement>().speed = 100;
                GameObject.FindWithTag("Car").GetComponent<CarMovement>().speed = 100;
            }
        }
        else
        {
            GameObject.FindWithTag("Car").GetComponent<CarMovement>().speed = 100;
        }
    }
}
