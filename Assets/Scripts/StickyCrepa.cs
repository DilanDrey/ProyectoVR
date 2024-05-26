using UnityEngine;

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
            collision.transform.localRotation = Quaternion.identity;

            Debug.Log($"Fresa pegada a la crepa en la posición {collision.transform.localPosition}");
        }
    }
}
