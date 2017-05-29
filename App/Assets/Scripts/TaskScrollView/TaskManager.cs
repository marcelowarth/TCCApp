using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public enum ManagerState { Idle, Dragging, SelectingSlot }
    public ManagerState managerState = ManagerState.Idle;
    public enum ExecutionState { None, Processing, Stopped, Completed}
    public ExecutionState executionState = ExecutionState.None;
    
    public GameObject prefabTaskPlaceHolder;
    public Transform mainCanvas;
    public Transform taskArea;
    [Header("Objects on scene")]
    public ConveyorBeltPegar conveyorPegar;
    public ConveyorBeltLevar conveyorLevar;
    public Worker worker;
    public HardwareSlotManager slotManager;
    public Speaker speaker;

    private Transform draggedTask;
    private Transform spawnedPlaceHolder;
    private TaskBase[] allTasks;
    private int currentTaskIndex;
    private GameObject taskSelecting;
    
    private void Update()
    {
        //print(state);
    }

    #region Dragging Tasks
    public void StartedDragging(Transform _draggedTask)
    {
        managerState = ManagerState.Dragging;
        draggedTask = _draggedTask;
        draggedTask.SetParent(mainCanvas);
        draggedTask.GetComponent<TaskBase>().bIsAtTaskArea = false;
    }
    public void EndedDragging()
    {
        managerState = ManagerState.Idle;
        if (!draggedTask || !spawnedPlaceHolder)
        {
            Destroy(draggedTask.gameObject);
        }
        else
        {
            draggedTask.SetParent(taskArea);
            draggedTask.SetSiblingIndex(spawnedPlaceHolder.GetSiblingIndex());
            draggedTask.GetComponent<TaskBase>().bIsAtTaskArea = true;
        }
        DestroyPlaceHolder();
    }
    public void SpawnPlaceHolder(int siblingIndex)
    {
        if (!spawnedPlaceHolder)
        {
            spawnedPlaceHolder = Instantiate(prefabTaskPlaceHolder, taskArea).transform;
        }
        spawnedPlaceHolder.SetSiblingIndex(siblingIndex);        
    }
    public void SpawnPlaceHolderOnLastSibling()
    {
        if (!spawnedPlaceHolder)
        {
            spawnedPlaceHolder = Instantiate(prefabTaskPlaceHolder, taskArea).transform;
        }
        spawnedPlaceHolder.SetAsLastSibling();
    }
    public void DestroyPlaceHolder()
    {
        if (spawnedPlaceHolder)
        {
            Destroy(spawnedPlaceHolder.gameObject);
        }        
    }
    #endregion
    #region Tasks Execution
    public void StartExecuteTasks()
    {
        executionState = ExecutionState.Processing;
        allTasks = taskArea.GetComponentsInChildren<TaskBase>();
        currentTaskIndex = 0;
        SetTaskCount();
        ExecuteTask(currentTaskIndex);
    }

    public void ExecuteTask(int index)
    {
        currentTaskIndex = index;
        AddTaskExecution();
        allTasks[index].ExecuteTask();
    }
    public void ExecuteNextTask()
    {
        currentTaskIndex++;
        if(currentTaskIndex >= allTasks.Length)
        {
            executionState = ExecutionState.Completed;
            StopAllActivities();
            if (conveyorLevar.bReceivedAllHardware)
            {
                Speaker.Inst.SetMessageAndColor("Parabens, você acaba de ganhar, 1 milhão de reais em barras de ouro que valem mais do que dinheiro!", Speaker.MessageType.Winner);
            }
        }
        else
        {
            ExecuteTask(currentTaskIndex);
        }        
    }
    public void ResetAllActivities()
    {
        executionState = ExecutionState.None;
        StopAllTasksExecution();
        allTasks = null;
        worker.ResetCharacter();
        conveyorPegar.ResetConveyor();
        conveyorLevar.ResetConveyor();
        slotManager.ResetSlotManager();
        speaker.ResetSpeaker();
    }
    public void StartGettingSlot(GameObject task)
    {
        managerState = ManagerState.SelectingSlot;
        taskSelecting = task;
    }
    public void SendSlotIndex(int index)
    {
        managerState = ManagerState.Idle;
        taskSelecting.SendMessage("SetSlotIndex", index);
        taskSelecting = null;
    }
    public bool HasAnyTaskOnTaskArea()
    {
        if(taskArea.GetComponentsInChildren<TaskBase>().Length > 0)
        {
            return true;
        }
        return false;
    }
    private void StopAllTasksExecution()
    {        
        foreach (TaskBase task in allTasks)
        {
            task.StopAllCoroutines();
        }
    }
    #endregion
    public void StopAllActivities()
    {
        executionState = ExecutionState.Stopped;
        StopAllTasksExecution();
        worker.StopCharacter();
    }
    private void AddTaskExecution()
    {
        if (allTasks[currentTaskIndex].bCountAsTask)
        {
            //Add o count de execuções
        }
    }
    private void SetTaskCount()
    {
        foreach (TaskBase task in allTasks)
        {
            if (task.bCountAsTask)
            {
                // add numero de comandos
            }
        }
    }
}
