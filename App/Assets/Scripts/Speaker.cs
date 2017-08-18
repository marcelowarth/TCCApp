using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speaker : MonoBehaviour
{
    public enum MessageType { Description, Error, Winner}
    public static Speaker Inst;
    public string challengeDescription;

    public GameObject descriptionBox;
    public GameObject lightning;
    public TaskManager taskManager;
    public Button closeBtn;
    public Button leftBtn;
    public Button rightBtn;
    public Toggle solutionBtn;
    public GameObject solutionScroll;
    [Header("Descricoes por pagina")]
    public string[] descriptions;
    private Animator anim;
    private bool bCanHideMessage = true;
    private int currentDescriptions;

    private void Awake()
    {
        Inst = this;
    }
    void Start ()
    {
        anim = GetComponent<Animator>();
        SetMessageAndColor(descriptions[0], MessageType.Description);
        solutionScroll.SetActive(false);
    }
    void Update ()
    {
        if (descriptionBox.activeSelf)
        {
            currentDescriptions = Mathf.Clamp(currentDescriptions, 0, descriptions.Length - 1);
            UpdateButtonsVisibility();
            if (Input.GetMouseButtonDown(0) && bCanHideMessage)
            {
                //descriptionBox.SetActive(false);
            }
        }
	}
    public void SetMessageAndColor(string message, MessageType type)
    {
        descriptionBox.SetActive(true);
        descriptionBox.GetComponentInChildren<Text>().text = message;
        switch (type)
        {
            case MessageType.Description:
                bCanHideMessage = true;
                break;
            case MessageType.Error:
                bCanHideMessage = false;
                taskManager.StopAllActivities();
                break;
            case MessageType.Winner:
                bCanHideMessage = false;
                break;
        }            
    }
    public void ResetSpeaker()
    {
        SetMessageAndColor(challengeDescription, MessageType.Description);
    }

    public void UpdateButtonsVisibility()
    {
        if (bCanHideMessage)
        {
            closeBtn.gameObject.SetActive(true);
            if (currentDescriptions == 0)
            {
                leftBtn.gameObject.SetActive(false);
            }
            else
            {
                leftBtn.gameObject.SetActive(true);
            }
            if (currentDescriptions == descriptions.Length - 1)
            {
                rightBtn.gameObject.SetActive(false);
                solutionBtn.gameObject.SetActive(true);
            }
            else
            {
                solutionScroll.gameObject.SetActive(false);
                solutionBtn.isOn = false;
                solutionBtn.gameObject.SetActive(false);
                rightBtn.gameObject.SetActive(true);
            }
        }
        else
        {
            closeBtn.gameObject.SetActive(false);
            leftBtn.gameObject.SetActive(false);
            rightBtn.gameObject.SetActive(false);
        }
    }
    public void ShowNextDescription(int value)
    {
        currentDescriptions += value;
        SetMessageAndColor(descriptions[currentDescriptions], MessageType.Description);
    }
}
