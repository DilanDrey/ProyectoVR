using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class UpdateCanvasTour : MonoBehaviour
{
    private int isNext = 0;
    public GameObject canvas;
    public GameObject station1;

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
                break;
            case 1:
                isNext++;
                break;
            case 2:
                isNext++;
                station1.SetActive(true);
                break;
            default:
                break;
        }
    }
}
