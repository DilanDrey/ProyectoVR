using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBladeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private Blender script;
    void Start()
    {
        script = transform.parent.gameObject.GetComponent<Blender>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dentro del onTrigger");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "bowlbatidora")
        {
            script.test();
        }
    }
}
