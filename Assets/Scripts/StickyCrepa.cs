using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CrepeSticky : MonoBehaviour
{
    // Este método se llama cuando un objeto entra en colisión con la crepa
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Colisiono el objeto {collision.gameObject.name}");
        // Verifica si el objeto que colisionó es una fresa
        if (collision.gameObject.name == "TS_Strawberry_001_Half")
        {
            // Hace que la fresa se convierta en hija de la crepa
            collision.transform.SetParent(transform);
            
            // Desactiva el Rigidbody para que la fresa no siga siendo afectada por la física
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            // Ajusta la posición local de la fresa para que quede correctamente posicionada en la crepa
            collision.transform.localPosition = transform.InverseTransformPoint(collision.transform.position);
            //collision.transform.localRotation = Quaternion.identity;
            collision.transform.localRotation = Quaternion.Euler(-90, 0, 0);

            Debug.Log($"Fresa pegada a la crepa en la posición {collision.transform.localPosition}");
        }
        if (collision.gameObject.name.Equals("cucharahelado"))
        {
            // Si no esta boca abajo se sale
            if (!(Vector3.Dot(collision.transform.up, Vector3.down) > 0)) return;

            List<String> strings = new List<string> { "heladochicle(Clone)", "heladochocolate(Clone)", "heladofresa(Clone)" };
            GameObject ob = null;
            foreach (string s in strings)
            {
                Debug.Log($"Buscando: {s}");
                Transform tf = collision.transform.Find(s);
                if (tf != null)
                {
                    ob = tf.gameObject;
                    if (ob != null)
                    {
                        Debug.Log($"Encontrado: {ob.name}");
                        break;
                    };
                }
            }
            if (ob == null) return;
            Debug.Log($"El helado es {ob.name}");

            ob.transform.SetParent(transform);
            ob.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            ob.transform.localPosition = new Vector3(ob.transform.localPosition.x, 0f, ob.transform.localPosition.z);
            collision.gameObject.GetComponent<CucharaEstacion6Script>().setNoIceCream();

        }
        if (collision.gameObject.name.Equals("marshmallows(Clone)"))
        {
            Debug.Log("Es un marshmellow");
            collision.transform.SetParent(transform);

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            //collision.gameObject.GetComponent<XRGrabInteractable>().gameObject.SetActive(false);
            collision.transform.localPosition = transform.InverseTransformPoint(collision.transform.position);
        }


        if (collision.gameObject.name == "blueberry(Clone)")
        {
            // Hace que la fresa se convierta en hija de la crepa
            collision.transform.SetParent(transform);


            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            // Desactiva el Rigidbody para que la fresa no siga siendo afectada por la física
            // Ajusta la posición local de la fresa para que quede correctamente posicionada en la crepa
            collision.transform.localPosition = transform.InverseTransformPoint(collision.transform.position);
            //collision.transform.localRotation = Quaternion.identity;
            collision.transform.localRotation = Quaternion.Euler(-90, 0, 0);

            Debug.Log($"Fresa pegada a la crepa en la posición {collision.transform.localPosition}");
        }
    }
}
