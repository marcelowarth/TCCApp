using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TaskArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TaskManager taskManager;
    private void Start()
    {
        taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (taskManager.managerState)
        {
            case TaskManager.ManagerState.Idle:
                break;
            case TaskManager.ManagerState.Dragging:
                    SpawnPlaceHolder();
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        taskManager.DestroyPlaceHolder();
    }

    public void SpawnPlaceHolder()
    {
        taskManager.SpawnPlaceHolderOnLastSibling();
    }
}
