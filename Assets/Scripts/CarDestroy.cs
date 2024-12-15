using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroy : MonoBehaviour
{
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
        if(other.gameObject.tag == "Car")
        {
            Destroy(other.gameObject);
            car.transform.position = spawn.transform.position;
            car.transform.rotation = other.transform.rotation;
            Instantiate(car);
        }
    }
}
