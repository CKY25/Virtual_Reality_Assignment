using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    
    public GameObject player;
    public GameObject car;
    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Activated");
            car.GetComponent<CarMovement>().speed = 100;
            car.transform.position = spawn.transform.position;
            car.transform.rotation = spawn.transform.rotation;
            Instantiate(car);

        }
    }
}
