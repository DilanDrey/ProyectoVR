using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRecorridoScript : MonoBehaviour
{

    public TextMeshProUGUI text;
    public TextMeshProUGUI button;
    public GameObject recorridoHandler;


    private int isNext;
    // Start is called before the first frame update
    void Start()
    {
        isNext = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButton()
    {
        
        switch (isNext)
        {
            case 0:
                text.text = " Primero practicaremos algunos movimientos, para asegurarnos que\ntengas la mejor experiencia durante la actividad";
                isNext = 1;
                break;
            case 1:
                text.text = "Da click en continuar para iniciar la experiencia.";
                button.text = "Empezar";
                isNext = 2;
                break;
            case 2:
                recorridoHandler.GetComponent<MeetTheKitchenScript>().activateFirstAnchor();
                break;
        }
    }
}
