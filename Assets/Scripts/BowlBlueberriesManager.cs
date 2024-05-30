using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlBlueberriesManager : MonoBehaviour
{
    public GameObject blueberryPrefab;
    public int numberOfBlueberries = 10;

    // Define el �rea en la que las blueberries pueden aparecer dentro del bowl
    public Vector3 spawnAreaCenter = new Vector3(-0.924f, -0.613f, 2.331f);
    public Vector3 spawnAreaSize = new Vector3(0.05f, 0.05f, 0.05f); // Ajusta este tama�o seg�n el tama�o del bowl

    void Start()
    {
        for (int i = 0; i < numberOfBlueberries; i++)
        {
            SpawnBlueberry();
        }
    }

    void SpawnBlueberry()
    {
        // Instanciar la blueberry y establecer su padre como el bowl
        GameObject newBlueberry = Instantiate(blueberryPrefab, transform);

        // Generar una posici�n aleatoria dentro del �rea de spawn
        Vector3 randomPosition = spawnAreaCenter + new Vector3(0f, 0f, 0.4f);

        // Asegurarse de que la posici�n local del bowl no se vea afectada
        newBlueberry.transform.localPosition = randomPosition;
        newBlueberry.transform.localRotation = Quaternion.identity;

        // Compensamos el cambio de la escala al cambiar el padre
        newBlueberry.transform.localScale = new Vector3(30f, 30f, 30f);

        // resize collider to half of currrent collider size
        BoxCollider collider = newBlueberry.GetComponent<BoxCollider>();
        collider.size = new Vector3(0.0002f, 0.0002f, 0.0002f) / 2;

        // R


        // Debugging logs
        Debug.Log($"Blueberry spawned at local position {newBlueberry.transform.localPosition} with scale {newBlueberry.transform.localScale}");
        Debug.Log($"Instantiated Blueberry at {newBlueberry.transform.localPosition} with parent {newBlueberry.transform.parent.name}");
    }
}
