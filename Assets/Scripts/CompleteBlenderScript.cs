using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public new AudioSource audio;
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
        Debug.Log($"El padre es: {transform.parent.name}");
        yield return new WaitForSeconds(10);
        audio.loop = false;
        blender.SetActive(true);
        bowl.SetActive(true);
        bowl.GetComponent<TazonEstacion2>().SetState(BowlState.Mixed);
        
        bowl.transform.localEulerAngles = Vector3.zero;
        bowl.transform.SetParent(transform.parent);
        bowl.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log($"El padre del bowl es: {bowl.transform.parent}");
        bowl.transform.position = new Vector3(-1.9559f, 0.9288f, -5.5064f);
        bowl.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gameObject.SetActive(false);
    }

    public void endBlending()
    {
        
        

    }
}
