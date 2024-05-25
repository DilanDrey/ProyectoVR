using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TazonEstacion2 : MonoBehaviour
{
    // Lista para almacenar los ingredientes
    private List<string> ingredientes;

    // Lista con el orden específico de los ingredientes permitidos
    private List<string> ordenIngredientes;

    // Índice actual en la secuencia de ingredientes
    private int indiceActual;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        ingredientes = new List<string>();
        ordenIngredientes = new List<string> { "huevosBatidos", "harina", "azucar", "leche", "aceite", "sal" };
        indiceActual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string objectName = collision.transform.gameObject.name;
        Debug.Log(objectName);

        if (objectName == "mesasdetrabajo")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            // Verificar si el objeto es el siguiente en el orden
            if (indiceActual < ordenIngredientes.Count && objectName == ordenIngredientes[indiceActual])
            {
                // Agregar el ingrediente a la lista
                ingredientes.Add(objectName);
                Debug.Log("Ingrediente agregado: " + objectName);

                // Avanzar al siguiente ingrediente en el orden
                indiceActual++;

                // Verificar si todos los ingredientes han sido agregados
                if (indiceActual == ordenIngredientes.Count)
                {
                    // Quitar los constraints del rigidbody
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    Debug.Log("Todos los ingredientes han sido agregados. Constraints eliminados.");
                }
            }
            else
            {
                Debug.Log("Ingrediente fuera de orden o no permitido: " + objectName);
            }
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.name != "mesasdetrabajo")
        {
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    // Método para obtener la lista de ingredientes
    public List<string> GetIngredientes()
    {
        return ingredientes;
    }
}
