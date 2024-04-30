using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TestScript : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    public TextMeshProUGUI text;
    public TextMeshProUGUI button;
    private int isNext = 0;
    private void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }


    public void startButton()
    {
        /*
        for (int i = 0; i < scenePaths.Length; i++)
        {
            Debug.Log(scenePaths[i]);
        }*/
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
                SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
                break;
        }
    }
}
