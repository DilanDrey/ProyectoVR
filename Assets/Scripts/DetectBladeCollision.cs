using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBladeCollision : MonoBehaviour
{
    private Blender script;

    // Start is called before the first frame update
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
            TazonEstacion2 tazonScript = other.GetComponent<TazonEstacion2>();
            if (tazonScript != null && tazonScript.AreIngredientsComplete())
            {
                tazonScript.StartMixing();
                script.test();
            }
            else
            {
                Debug.Log("Ingredientes incompletos. No se puede activar la batidora.");
            }
        }
    }
}
