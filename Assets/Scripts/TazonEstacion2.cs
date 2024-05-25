using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BowlState
{
    Empty,
    PartialIngredients,
    CompleteIngredients,
    Mixing,
    Mixed
}

public class TazonEstacion2 : MonoBehaviour
{
    public GameObject emptyBowl;
    public GameObject partialIngredientsBowl;
    public GameObject completeIngredientsBowl;
    public GameObject mixingBowl;
    public GameObject mixedBowl;

    private List<string> ingredientes;
    private List<string> ordenIngredientes;
    private int indiceActual;
    private BowlState currentState;

    // Start is called before the first frame update
    void Start()
    {
        ingredientes = new List<string>();
        ordenIngredientes = new List<string> { "huevosBatidos" }; // , "harina", "azucar", "leche", "aceite", "sal"
        indiceActual = 0;
        SetState(BowlState.Empty);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        string objectName = collision.transform.gameObject.name;
        Debug.Log(objectName);

        if (objectName != "mesasdetrabajo")
        {
            if (indiceActual < ordenIngredientes.Count && objectName == ordenIngredientes[indiceActual])
            {
                ingredientes.Add(objectName);
                Debug.Log("Ingrediente agregado: " + objectName);
                indiceActual++;

                if (indiceActual == ordenIngredientes.Count)
                {
                    SetState(BowlState.CompleteIngredients);
                }
                else
                {
                    SetState(BowlState.PartialIngredients);
                }
            }
            else
            {
                Debug.Log("Ingrediente fuera de orden o no permitido: " + objectName);
            }
        }
    }

    public List<string> GetIngredientes()
    {
        return ingredientes;
    }

    public bool AreIngredientsComplete()
    {
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

    public void StartMixing()
    {
        if (currentState == BowlState.CompleteIngredients)
        {
            SetState(BowlState.Mixing);
            StartCoroutine(MixCoroutine());
        }
    }

    private IEnumerator MixCoroutine()
    {
        yield return new WaitForSeconds(5); // Simula el tiempo de mezcla
        SetState(BowlState.Mixed);
    }

    private void SetState(BowlState newState)
    {
        currentState = newState;
        UpdateBowlAppearance();
    }

    private void UpdateBowlAppearance()
    {
        emptyBowl.SetActive(currentState == BowlState.Empty);
        partialIngredientsBowl.SetActive(currentState == BowlState.PartialIngredients);
        completeIngredientsBowl.SetActive(currentState == BowlState.CompleteIngredients);
        mixingBowl.SetActive(currentState == BowlState.Mixing);
        mixedBowl.SetActive(currentState == BowlState.Mixed);
    }
}
