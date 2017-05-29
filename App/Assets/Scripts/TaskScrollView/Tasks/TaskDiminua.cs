using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDiminua : TaskCopyTo
{
    public override void ExecuteTask()
    {
        StartCoroutine(DecreaseHardwareValue());
    }
    private IEnumerator DecreaseHardwareValue()
    {
        Slot slot = taskManager.slotManager.GetSlot(slotIndex);
        taskManager.worker.SetDestination(slot.transform.position + new Vector3(0.5f, 0));
        yield return new WaitUntil(() => taskManager.worker.IsWorkerAtDestination());
        taskManager.worker.DecreaseSlotHardwareValue(slot);
        taskManager.ExecuteNextTask();
    }
}
