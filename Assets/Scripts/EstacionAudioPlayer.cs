using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacion2AudioHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playAudio()
    {
        Debug.Log("Estoy reproduciendo el audio");
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        
    }
}
