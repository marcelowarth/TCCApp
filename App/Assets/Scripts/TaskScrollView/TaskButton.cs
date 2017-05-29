using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public enum ButtonState { Fixed, Dragging}
    public ButtonState                                                  state;
    public bool bIsSpawner;

    private TaskManager                                                 taskManager;
    private Vector2                                                     offset;
    private Button                                                      button;

    void Start()
    {
        button = GetComponent<Button>();
        state = ButtonState.Fixed;
        taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
    }

    private void Update()
    {
        if (bIsSpawner)
        {
            switch (taskManager.executionState)
            {
                case TaskManager.ExecutionState.None:
                    button.interactable = true;
                    break;
                case TaskManager.ExecutionState.Processing:
                    button.interactable = false;
                    break;
                case TaskManager.ExecutionState.Stopped:
                    button.interactable = false;
                    break;
                case TaskManager.ExecutionState.Completed:
                    button.interactable = false;
                    break;
            }
        }        
        if (taskManager.managerState == TaskManager.ManagerState.SelectingSlot)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!button.interactable)
        {
            return;
        }
        if (bIsSpawner)
        {
            GameObject twinButton = Instantiate(gameObject, transform.parent);
        }
        taskManager.StartedDragging(transform);        
        offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
        transform.position = eventData.position - offset;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!button.interactable)
        {
            return;
        }
        transform.position = eventData.position - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!button.interactable)
        {
            return;
        }
        bIsSpawner = false;
        taskManager.EndedDragging();
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (taskManager.managerState)
        {
            case TaskManager.ManagerState.Idle:
                break;
            case TaskManager.ManagerState.Dragging:
                if (!bIsSpawner)
                {
                    SpawnPlaceHolder();
                }                
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    private void SpawnPlaceHolder()
    {
        taskManager.SpawnPlaceHolder(transform.GetSiblingIndex());
    }
}
