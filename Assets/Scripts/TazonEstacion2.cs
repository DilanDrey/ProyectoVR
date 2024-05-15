using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TazonEstacion2 : MonoBehaviour
{
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
        GetComponent<Collider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<XRGrabInteractable>().enabled = true;
        Debug.Log(GetComponent<XRGrabInteractable>().enabled);
        Debug.Log(other.gameObject.transform.rotation.eulerAngles.ToString());
    }
}
