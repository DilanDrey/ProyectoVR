using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispensadorScript : MonoBehaviour
{
    enum DispensadorState
    {
        Empty,
        Filled
    }

    private DispensadorState state; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"El hijo es: {transform.GetChild(1).name}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == DispensadorState.Filled) return;
        if (collision.transform.name.Equals("bowlbatidora"))
        {
            TazonEstacion2 tz = collision.gameObject.GetComponent<TazonEstacion2>();
            if (Vector3.Dot(collision.transform.up, Vector3.down) > 0)
            {
                Debug.Log("El bowl esta viendo hacia abajo");
                
                if (tz.IsMixed())
                {
                    Rigidbody rb = GetComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.None;
                    state = DispensadorState.Filled;
                }
                
            }
        }
    }

    public bool isFilled()
    {
        if (state == DispensadorState.Filled) return true;
        return false;
    }
}
