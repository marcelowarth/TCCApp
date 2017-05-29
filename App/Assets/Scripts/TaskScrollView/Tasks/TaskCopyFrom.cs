using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCopyFrom : TaskCopyTo
{
    public override void ExecuteTask()
    {
        StartCoroutine(CopyFromSlot());
    }
    private IEnumerator CopyFromSlot()
    {
        Slot slot = taskManager.slotManager.GetSlot(slotIndex);
        taskManager.worker.SetDestination(slot.transform.position + new Vector3(0.5f, 0));
        yield return new WaitUntil(() => taskManager.worker.IsWorkerAtDestination());
        taskManager.worker.CopyFrom(slot);
        taskManager.ExecuteNextTask();
    }
}
