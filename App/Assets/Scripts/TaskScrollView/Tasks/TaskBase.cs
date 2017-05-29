using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBase : MonoBehaviour
{
    public bool bCountAsTask = true;
    public TaskManager taskManager;
    public bool bIsAtTaskArea;
    public void Start()
    {
        bIsAtTaskArea = false;
        taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
    }

    public virtual void ExecuteTask()
    {

    }
}
