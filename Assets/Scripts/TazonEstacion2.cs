using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TazonEstacion2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.gameObject.name);
        Debug.Log(collision.transform.gameObject.name=="mesasdetrabajo");
        if (collision.transform.gameObject.name != "mesasdetrabajo")
        {
            Debug.Log(collision.gameObject.name);
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.name != "mesasdetrabajo")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        
    }
}
