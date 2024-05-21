using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUpsideDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            Debug.Log("Esta viendo hacia abajo");
            
        }
        else if (Vector3.Dot(transform.forward, Vector3.down) > 0)
        {
            Debug.Log(name);
            Debug.Log("Esta viendo hacia abajo");
            
        }
    }

    public bool checkUpsideDown()
    {
        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            Debug.Log("Esta viendo hacia abajo");
            return true;
        } else if (Vector3.Dot(transform.up, Vector3.back) > 0)
        {
            Debug.Log("Esta viendo hacia abajo");
            return true;
        }
        return false;
    }
}
