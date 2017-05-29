using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBase : MonoBehaviour
{
    public enum TaskType { PegarEntrada, LevarSaida, PularPara, CopiarPara, CopiarDe, SeZero, SeNegativo, Aumente, Diminua, SomarCom, DiminuirCom, Dummy}
    public TaskType myType;
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
