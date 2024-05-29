using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CucharaEstacion6Script : MonoBehaviour
{

    public GameObject heladoFresa;
    public GameObject heladoChocolate;
    public GameObject heladoChicle;

    private string currentHelado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        // Guarda el color de Gizmos original
        Gizmos.color = UnityEngine.Color.red;

        // Establece el color de los Gizmos

        // Dibuja un cubo en la posición del objeto con el tamaño especificado
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 0.0239f, 0.0483f), new Vector3(0.1f, 0.1f, 0.1f));

        // Restaura el color original de Gizmos
    }

    public void addIceCream(int tipo)
    {
        GameObject helado = null;
        switch (tipo)
        {
            case 0:
                helado = Instantiate(heladoFresa, transform);
                break;
            case 1:
                helado = Instantiate(heladoChocolate, transform);
                break;
            case 2:
                helado = Instantiate(heladoChicle, transform);
                break;
            default:
                helado = null;
                break;
        }
        if (helado == null) return;
        currentHelado = helado.name;
        Debug.Log($"El nombre de la nueva instancia: {currentHelado}");
        helado.transform.localPosition = new Vector3(0, 0.0239f, 0.0483f);
        helado.transform.localRotation = Quaternion.Euler(90, 0, 0);
    }
}
