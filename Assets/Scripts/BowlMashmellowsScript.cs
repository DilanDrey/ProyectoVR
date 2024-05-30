using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlMashmellowsScript : MonoBehaviour
{

    public GameObject marshmellowPrefab;
    public GameObject bowl;

    public Vector3 spawnPosition =  new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnMarshmellow()
    {
        Debug.Log("------------------------------------------------------------------------");
        int marshCount = 0;
        int childCount = bowl.transform.childCount;
        Debug.Log(bowl.transform.childCount);
        for (int i = 0; i < childCount; i++)
        {
            
            GameObject ob = bowl.transform.GetChild(i).gameObject;
            Debug.Log(ob.gameObject.name);
            if (ob.gameObject.name.Equals("marshmallows(Clone)"))
            {
                marshCount++;
            }
        }
        if (marshCount == 0)
        {
            GameObject ob = Instantiate(marshmellowPrefab, bowl.transform);
            ob.transform.localPosition = spawnPosition;
        }
        Debug.Log("------------------------------------------------------------------------");
    }
    
}
