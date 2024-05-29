using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowHeladoScript : MonoBehaviour
{

    public enum TipoHelado
    {
        fresa,
        chocolate,
        chicle
    }
    public TipoHelado tipo; 
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
        Debug.Log($"{other.transform.name}");
        if (other.gameObject.transform.name.Equals("spoon_001_mesh"))
        {
            Debug.Log("Es la cuchara");
            GameObject spoon =other.transform.parent.gameObject;
            spoon.GetComponent<CucharaEstacion6Script>().addIceCream((int)tipo);
        }
    }
}
