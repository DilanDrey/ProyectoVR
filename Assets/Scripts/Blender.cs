using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    public GameObject blenderWithBowl;
    public GameObject bowl;
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
        /*
        Debug.Log("Dentro del onTrigger");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "bowlbatidora")
        {

            //gameObject.SetActive(false);
            Debug.Log("Es la batidora");
            blenderWithBowl.SetActive(true);
            gameObject.SetActive(false);
        }
        */
    }
    public void test()
    {
        Debug.Log("Desde el script del hijo ");
        blenderWithBowl.SetActive(true);
        bowl.SetActive(false);
        gameObject.SetActive(false);

    }
}
