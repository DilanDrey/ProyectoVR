using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject partialIngredientsBowl;
    public GameObject completeIngredientsBowl;
    public GameObject mixingBowl;
    public GameObject mixedBowl;
    public AudioClip liquidSound;
    public AudioClip solidSound;

    private List<string> ingredientes;
    private List<string> ordenIngredientes;
    private int indiceActual;
    private BowlState currentState;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        source = GetComponent<AudioSource>();
        ingredientes = new List<string>();
        ordenIngredientes = new List<string> { "huevosBatidos", "aceite", "leche", "azucar", "SaltShaker", "harina" }; // , "harina", "azucar", "leche", "aceite", "sal"
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

        if (currentState != BowlState.Empty && currentState != BowlState.PartialIngredients) return;
        if (objectName != "mesasdetrabajo")
        {
            if (indiceActual < ordenIngredientes.Count && objectName == ordenIngredientes[indiceActual])
            {

                playAudio(collision.transform.tag.Equals("LiquidIngredent"));
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

    public void OnCollisionExit(Collision collision)
    {
        if (indiceActual == ordenIngredientes.Count)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    private void playAudio(bool isLiquid)
    {
        if (isLiquid)
        {
            source.clip = liquidSound;
        } else
        {
            source.clip = solidSound;
        }
        source.Play();

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

    public void SetState(BowlState newState)
    {
        currentState = newState;
        UpdateBowlAppearance();
    }

    private void UpdateBowlAppearance()
    {
        partialIngredientsBowl.SetActive(currentState == BowlState.PartialIngredients);
        completeIngredientsBowl.SetActive(currentState == BowlState.CompleteIngredients);
        mixingBowl.SetActive(currentState == BowlState.Mixing);
        mixedBowl.SetActive(currentState == BowlState.Mixed);
    }

    public bool IsMixed()
    {
        if (currentState == BowlState.Mixed) return true;
        return false;
    }
}
