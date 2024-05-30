using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    public GameObject blenderWithBowl;
    public GameObject bowl;
    private TazonEstacion2 tazonEstacion2;

    // Start is called before the first frame update
    void Start()
    {
        tazonEstacion2 = bowl.GetComponent<TazonEstacion2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comentado el código original
    }

    public void test()
    {
        blenderWithBowl.SetActive(true);
        bowl.SetActive(false);
        gameObject.SetActive(false);
    }

    public bool AreIngredientsComplete()
    {
        List<string> ingredientes = tazonEstacion2.GetIngredientes();
        List<string> ordenIngredientes = new List<string> { "huevosBatidos", "aceite", "leche", "azucar", "SaltShaker", "harina" }; // , "harina", "azucar", "leche", "aceite", "sal"

        if (ingredientes.Count != ordenIngredientes.Count)
        {
            return false;
        }

        for (int i = 0; i < ordenIngredientes.Count; i++)
        {
            if (ingredientes[i] != ordenIngredientes[i])
            {
                return false;
            }
        }

        return true;
    }
}
