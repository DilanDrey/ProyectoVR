using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class BowlFresasManager : MonoBehaviour
{
    public GameObject fresaPrefab;
    public int numberOfFresas = 10;
    public Vector3 correctScale = new Vector3(0.1f, 0.1f, 0.1f); // Escala de referencia

    // Define el área en la que las fresas pueden aparecer dentro del bowl
    public Vector3 spawnAreaCenter = Vector3.zero;
    public Vector3 spawnAreaSize = new Vector3(0.1f, 0.1f, 0.1f); // Ajusta este tamaño según el tamaño del bowl

    void Start()
    {
        for (int i = 0; i < numberOfFresas; i++)
        {
            SpawnFresa();
        }
    }

    void SpawnFresa()
    {
        // Instanciar la fresa y establecer su padre como el bowl
        GameObject newFresa = Instantiate(fresaPrefab, transform);

        // Generar una posición aleatoria dentro del área de spawn
        Vector3 randomPosition = spawnAreaCenter + new Vector3(0f, 0f, 0.3f);

        // Asegurarse de que la posición local del bowl no se vea afectada
        newFresa.transform.localPosition = randomPosition;
        newFresa.transform.localRotation = Quaternion.identity;
        newFresa.transform.localScale = correctScale;


        Rigidbody rb = newFresa.AddComponent<Rigidbody>();
        rb.mass = 1;
        rb.drag = 0;
        rb.angularDrag = 0.05f;
        rb.useGravity = true;

        // Buscar los objetos hijos dentro de la fresa instanciada
        Transform fresa = newFresa.transform.Find("TS_Strawberry_001_Half");

        // Asegurarse de que los objetos hijos existen y aplicar las transformaciones deseadas
        if (fresa != null)
        {
            fresa.localPosition = Vector3.zero;
            fresa.localRotation = Quaternion.identity;
            fresa.localScale = correctScale;
            BoxCollider collider = fresa.gameObject.AddComponent<BoxCollider>();
            collider.size = new Vector3(0.104f, 0.152f, 0.025f); // Ajusta el tamaño del collider según tus necesidades
            collider.center = new Vector3(-0.002935059f, 0.1481347f, 0.04976335f); // Ajusta la posición del collider según tus necesidades
            XRGrabInteractable interactable = fresa.gameObject.AddComponent<XRGrabInteractable>();
            Debug.Log($"Adjusted TS_Strawberry_001_Half position to {fresa.localPosition}, and scale to {fresa.localScale}");
        }
        else
        {
            Debug.LogError("No se encontró el objeto TS_Strawberry_001_Half");
        }

        Debug.Log($"Instantiated Fresa at {newFresa.transform.localPosition} with parent {newFresa.transform.parent.name}");
    }
}
