using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecutionButtons : MonoBehaviour
{
    public Button playButton;
    public Button stopButton;
    public TaskManager taskManager;

	void Start ()
    {
        UpdateButtonInteraction();
    }
	
	void Update ()
    {
        UpdateButtonInteraction();
	}

    void UpdateButtonInteraction()
    {
        switch (taskManager.executionState)
        {
            case TaskManager.ExecutionState.None:
                playButton.interactable = taskManager.HasAnyTaskOnTaskArea();
                stopButton.interactable = false;
                break;
            case TaskManager.ExecutionState.Processing:
                playButton.interactable = false;
                stopButton.interactable = true;
                break;
            case TaskManager.ExecutionState.Stopped:
                playButton.interactable = false;
                stopButton.interactable = true;
                break;
            case TaskManager.ExecutionState.Completed:
                playButton.interactable = false;
                stopButton.interactable = true;
                break;
        }
    }
}
