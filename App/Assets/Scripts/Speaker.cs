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
    private Animator anim;
    private bool bCanHideMessage = true;

    private void Awake()
    {
        Inst = this;
    }
    void Start ()
    {
        anim = GetComponent<Animator>();
        SetMessageAndColor(challengeDescription, MessageType.Description);
    }	
	void Update ()
    {
        if (descriptionBox.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && bCanHideMessage)
            {
                descriptionBox.SetActive(false);
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
}
