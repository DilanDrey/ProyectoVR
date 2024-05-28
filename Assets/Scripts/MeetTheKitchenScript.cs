using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MeetTheKitchenScript : MonoBehaviour
{

    public GameObject[] stations;

    public AudioSource source;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var station in stations)
        {
            station.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateFirstAnchor()
    {
        if (!stations[0].activeSelf)
        {
            stations[0].SetActive(true);
        }

    }

    public void onTeleportAnchor(int stationNumber)
    {
        
        stations[stationNumber].SetActive(false);
        if (stationNumber!=5)
        stations[stationNumber+1].SetActive(true);
    }

    public void startSecondTask()
    {
        source.PlayOneShot(clips[0]);
    }
}
