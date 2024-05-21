using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBlending()
    {
        audio.loop = true;
        audio.Play();
        Thread.Sleep(2000);
        audio.loop = false;
    }
}
