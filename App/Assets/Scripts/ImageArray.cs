using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageArray : MonoBehaviour {

    Image myImageComponent;

    public Sprite[] backgroundImages;
    public int pos = 0;

    public GameObject backButton;
    public GameObject nextButton;
    public GameObject menuButton;
    public GameObject nextDecadeButton;
    public GameObject menuButtonRight;
    public bool isLastDecade;

    void Start()
    {
        myImageComponent = GetComponent<Image>();
        
        myImageComponent.sprite = backgroundImages[pos];
        ManageButtons();
    }

    private void ManageButtons()
    {
        nextDecadeButton.SetActive(false);
        menuButtonRight.SetActive(false);

        if (pos == 0)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }

        if(pos == backgroundImages.Length - 1)
        {
            nextButton.SetActive(false);
            menuButton.SetActive(false);
            nextDecadeButton.SetActive(true);
            menuButtonRight.SetActive(true);
        }
        else
        {
            nextButton.SetActive(true);
            menuButton.SetActive(true);
        }

        if(isLastDecade)
        {
            nextDecadeButton.SetActive(false);
        }
    }

    public void NextImage()
    {
        if (pos < backgroundImages.Length - 1)
        {
            pos++;
        }
        ManageButtons();
        myImageComponent.sprite = backgroundImages[pos];
    }

    public void BackImage()
    {
        if (pos > 0)
        {
            pos--;
        }
        ManageButtons();
        myImageComponent.sprite = backgroundImages[pos];
    }
}
