using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskManager : MonoBehaviour
{
    public enum ManagerState { Idle, Dragging, SelectingSlot }
    public ManagerState managerState = ManagerState.Idle;
    public enum ExecutionState { None, Processing, Stopped, Completed}
    public ExecutionState executionState = ExecutionState.None;

    public List<string> alphabet = new List<string>();
    
    private int currentAlphaIndex;
    private int alphaLoops = 1;
    public GameObject prefabTaskPlaceHolder;
    public Transform mainCanvas;
    public Transform taskArea;
    public GameObject victoryScreen;
    public GameObject prefabExecutionArrow;
    private RectTransform executionArrow;
    [Header("Objects on scene")]
    public ConveyorBeltPegar conveyorPegar;
    public ConveyorBeltLevar conveyorLevar;
    public Worker worker;
    public HardwareSlotManager slotManager;
    public Speaker speaker;
    [Header("Requiriments to get stars")]
    public int maxTaskExecutions;
    public int maxTaskCount;
    [HideInInspector]
    public int taskExecutions;
    [HideInInspector]
    public int taskCount;   


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
        executionArrow = Instantiate(prefabExecutionArrow, mainCanvas).GetComponent<RectTransform>();
        executionState = ExecutionState.Processing;
        allTasks = taskArea.GetComponentsInChildren<TaskBase>();
        currentTaskIndex = 0;
        SetTaskCount();
        ExecuteTask(currentTaskIndex);
    }

    public void ExecuteTask(int index)
    {
        if (executionState == ExecutionState.Processing)
        {
            currentTaskIndex = index;
            AddTaskExecution();
            allTasks[index].ExecuteTask();
            executionArrow.position = allTasks[index].GetComponent<RectTransform>().position - new Vector3(62, 0);
        }        
    }
    public void ExecuteNextTask()
    {        
        currentTaskIndex++;
        if (conveyorLevar.bReceivedAllHardware)
        {
            executionState = ExecutionState.Completed;
            StopAllActivities();
            Speaker.Inst.SetMessageAndColor("Parabéns!", Speaker.MessageType.Winner);
            Invoke("ShowVictoryScreen", 2f);
        }
        else if (currentTaskIndex >= allTasks.Length)
        {
            executionState = ExecutionState.Completed;
            StopAllActivities();            
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
        taskExecutions = 0;
        taskCount = 0;
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
        if (executionArrow)
        {
            Destroy(executionArrow.gameObject);
        }
        foreach (TaskBase task in allTasks)
        {
            task.StopAllCoroutines();
        }
    }
    #endregion
    public void StopAllActivities()
    {
        if(executionState != ExecutionState.None)
        {
            executionState = ExecutionState.Stopped;
        }        
        StopAllTasksExecution();
        worker.StopCharacter();
    }
    private void AddTaskExecution()
    {
        if (allTasks[currentTaskIndex].bCountAsTask)
        {
            taskExecutions++;
        }
    }
    private void SetTaskCount()
    {
        foreach (TaskBase task in allTasks)
        {
            if (task.bCountAsTask)
            {
                taskCount++;
            }
        }
    }

    private void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
    }

    public string GetIndexLetter()
    {
        string newIndex = "";
        currentAlphaIndex++;
        if(currentAlphaIndex > alphabet.Count)
        {
            currentAlphaIndex = 1;
            alphaLoops++;
        }
        for (int i = 0; i < alphaLoops; i++)
        {
            newIndex += alphabet[currentAlphaIndex - 1];
        }
        return newIndex;
    }
}
