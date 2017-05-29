using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TaskCopyTo : TaskBase
{
    public Toggle slotButton;
    public Text slotText;
    public int slotIndex = 0;
	new void Start ()
    {
        base.Start();
        slotButton.gameObject.SetActive(bIsAtTaskArea);
	}
    private void Update()
    {
        slotButton.gameObject.SetActive(bIsAtTaskArea);
        if (bIsAtTaskArea)
        {
            slotText.text = (slotIndex + 1).ToString();
        }
        if(slotButton.isOn && bIsAtTaskArea)
        {
            if(taskManager.managerState != TaskManager.ManagerState.SelectingSlot)
            {
                taskManager.StartGettingSlot(gameObject);
            }
        }
        if(taskManager.managerState == TaskManager.ManagerState.SelectingSlot)
        {
            slotButton.interactable = false;
        }
        else
        {
            slotButton.interactable = true;
        }
    }

    public void SetSlotIndex(int index)
    {
        slotIndex = index;
        slotButton.isOn = false;
    }

    public override void ExecuteTask()
    {
        StartCoroutine(CopyToSlot());
    }
    private IEnumerator CopyToSlot()
    {
        Slot slot = taskManager.slotManager.GetSlot(slotIndex);
        taskManager.worker.SetDestination(slot.transform.position + new Vector3(0.5f, 0));
        yield return new WaitUntil(() => taskManager.worker.IsWorkerAtDestination());
        taskManager.worker.CopyTo(slot);
        taskManager.ExecuteNextTask();
    }
}
