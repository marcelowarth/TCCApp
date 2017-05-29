using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public TaskManager taskManager;
    public GameObject[] stars;
    public Text taskCount;
    public Text maxTaskCount;
    public Text taskExecutions;
    public Text maxTaskExecutions;
    public Color wrongColor;

    public void Start()
    {
        SetVictoryTexts();
    }
    private void OnEnable()
    {
        SetVictoryTexts();
    }

    void SetVictoryTexts()
    {
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        if (taskManager.taskCount <= taskManager.maxTaskCount)
        {
            
            stars[1].SetActive(true);
        }
        else
        {
            taskCount.color = wrongColor;
        }
        if(taskManager.taskExecutions <= taskManager.maxTaskExecutions)
        {            
            stars[2].SetActive(true);
        }
        else
        {
            taskExecutions.color = wrongColor;
        }
        taskCount.text = taskManager.taskCount.ToString();
        maxTaskCount.text = "/" + taskManager.maxTaskCount.ToString();
        taskExecutions.text = taskManager.taskExecutions.ToString();
        maxTaskExecutions.text = "/" + taskManager.maxTaskExecutions.ToString();
    }
}
