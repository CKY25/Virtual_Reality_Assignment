using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrafficLightTrigger : MonoBehaviour
{
    public GameObject leftController;
    public GameObject rightController;
    public GameObject floorTrigger;
    public Material lightMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
       lightMaterial.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ReactivateTrigger()
    {
        yield return new WaitForSeconds(10f);
        floorTrigger.SetActive(true);
        lightMaterial.color = Color.red;

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == rightController.tag)
        {
            lightMaterial.color = Color.green;
            floorTrigger.SetActive(false);
            StartCoroutine(ReactivateTrigger());
        }
    }


}
