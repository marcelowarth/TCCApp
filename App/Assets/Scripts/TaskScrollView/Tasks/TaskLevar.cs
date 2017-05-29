using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskLevar : TaskBase
{
    private new void Start()
    {
        base.Start();
    }

    public override void ExecuteTask()
    {
        StartCoroutine(TakeObject());
    }

    private IEnumerator TakeObject()
    {
        taskManager.worker.SetDestination(taskManager.conveyorLevar.pointOfAccess.position);
        yield return new WaitUntil(() => taskManager.worker.IsWorkerAtDestination());
        taskManager.worker.LeaveHardwareOnConveyor();
        taskManager.ExecuteNextTask();
    }
}
