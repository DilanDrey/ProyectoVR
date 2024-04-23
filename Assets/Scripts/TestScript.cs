using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

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
        SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
    }
}
