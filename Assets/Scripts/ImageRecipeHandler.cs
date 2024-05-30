using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ImageRecipeHandler : MonoBehaviour
{
    
    public Texture[] imagenes;
    public Button nextButton, previousButton;
    public GameObject recorridoHandler;

    private RawImage image;
    private int currentImage;
    
    // Start is called before the first frame update
    void Start()
    {
        currentImage = 0;
        image  = GetComponentInChildren<RawImage>();
        if (imagenes.Length > 0)
        {
            image.texture = imagenes[0];
            if (imagenes.Length > 1)
            {
                nextButton.gameObject.SetActive(true);
            }
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void previousImage()
    {
        if (currentImage > 0)
        {
            currentImage--;
            image.texture = imagenes[currentImage];
            nextButton.gameObject.SetActive(true);
        }

        previousButton.gameObject.SetActive(currentImage > 0);
    }

    public void nextImage()
    {
        Debug.Log($"Current {currentImage}, lenght {imagenes.Length}");
        
        if (currentImage < imagenes.Length - 1)
        {
            currentImage++;
            image.texture = imagenes[currentImage];
            previousButton.gameObject.SetActive(true);
        }
        if (currentImage == (imagenes.Length - 1))
        {
            recorridoHandler.GetComponent<MeetTheKitchenScript>().activateFirstAnchor();
        }
        nextButton.gameObject.SetActive(currentImage < imagenes.Length - 1);
    }
}
