using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlBlueberriesManager : MonoBehaviour
{
    public GameObject blueberryPrefab;
    public int numberOfBlueberries = 10;

    // Define el área en la que las blueberries pueden aparecer dentro del bowl
    public Vector3 spawnAreaCenter = new Vector3(-0.924f, -0.613f, 2.331f);
    public Vector3 spawnAreaSize = new Vector3(0.1f, 0.1f, 0.1f); // Ajusta este tamaño según el tamaño del bowl

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

        // Generar una posición aleatoria dentro del área de spawn
        Vector3 randomPosition = spawnAreaCenter + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // Asegurarse de que la posición local del bowl no se vea afectada
        newBlueberry.transform.localPosition = randomPosition;
        newBlueberry.transform.localRotation = Quaternion.identity;

        // Compensamos el cambio de la escala al cambiar el padre
        newBlueberry.transform.localScale = new Vector3(30f, 30f, 30f);

        // Debugging logs
        Debug.Log($"Blueberry spawned at local position {newBlueberry.transform.localPosition} with scale {newBlueberry.transform.localScale}");
        Debug.Log($"Instantiated Blueberry at {newBlueberry.transform.localPosition} with parent {newBlueberry.transform.parent.name}");
    }
}
