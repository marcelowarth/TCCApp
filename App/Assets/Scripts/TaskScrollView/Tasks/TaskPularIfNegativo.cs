using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPularIfNegativo : TaskPularFrom
{
    new public void Start()
    {
        base.Start();
    }
    new public void Update()
    {
        base.Update();
    }
    public override void ExecuteTask()
    {
        if (taskManager.worker.GetCarryingHardware())
        {
            if(taskManager.worker.GetCarryingHardware().hardwareValue < 0)
            {
                taskManager.ExecuteTask(jumpTo.GetSiblingIndex());
            }
            else
            {
                taskManager.ExecuteNextTask();
            }
        }
        else
        {
            Speaker.Inst.SetMessageAndColor("Este comando não pode ser realizado de mãos vazias!", Speaker.MessageType.Error);
        }
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
