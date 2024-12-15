using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextDestination : MonoBehaviour
{
    public GameObject destination;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            destination.SetActive(true);
        }
    }
}
