using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public AudioSource audio;
    public GameObject blender;
    public GameObject bowl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void blenderButton()
    {
        StartCoroutine(startBlending());
        
    }

    IEnumerator startBlending()
    {
        audio.loop = true;
        audio.Play();
        yield return new WaitForSeconds(30);
        audio.loop = false;
        blender.SetActive(true);
        bowl.SetActive(true);
        bowl.gameObject.transform.Translate(new Vector3(-0.9117f, -0.5814f, -2.2393f));
        gameObject.SetActive(false);
    }

    public void endBlending()
    {
        
        

    }
}
