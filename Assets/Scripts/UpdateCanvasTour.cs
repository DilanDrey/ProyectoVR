using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class UpdateCanvasTour : MonoBehaviour
{
    private int isNext = 0;
    public GameObject button;
    public GameObject station1;
    public TextMeshProUGUI textCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextButton()
    {
        switch (isNext)
        {
            case 0:
                isNext++;
                textCanvas.text = "Teletransportate hacia la estacion 1.";
                station1.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void updateCanvasTask2()
    {
        textCanvas.text = "Teletransportate a la estacion 1 para continuar.";
    }
}
