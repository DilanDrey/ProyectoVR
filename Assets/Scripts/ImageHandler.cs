using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour
{
    
    public Texture[] imagenes;
    public Button nextButton, previousButton;


    private RawImage image;
    private int currentImage;
    
    // Start is called before the first frame update
    void Start()
    {
        currentImage = 0;
        image  = GetComponentInChildren<RawImage>();
        if (imagenes.Length > 1)
        {
            nextButton.gameObject.SetActive(true);
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void previousImage()
    {
        if (currentImage != 0)
        {
            Debug.Log($"Foto anterior {image.texture.name}");
            currentImage--;
            image.texture=imagenes[currentImage];
        }
        if (currentImage==0)
        {
            previousButton.gameObject.SetActive(false);
            if (imagenes.Length > 1)
            {
                nextButton.gameObject.SetActive(true);
            }
        }
    }

    public void nextImage()
    {
        if (!previousButton.gameObject.activeSelf)
        {
            previousButton.gameObject.SetActive(true);
        }
        if (currentImage != imagenes.Length - 1)
        {
            Debug.Log($"Foto siguiente {image.texture.name}");
            currentImage++;
            image.texture = imagenes[currentImage];
        };
        if (currentImage == imagenes.Length-1) 
        {
            nextButton.gameObject.SetActive(false);
        }
    }
}
