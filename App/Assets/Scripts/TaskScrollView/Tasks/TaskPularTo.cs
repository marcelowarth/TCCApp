using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPularTo : TaskBase
{
    private Transform jumpFrom;
    private new void Start()
    {
        base.Start();
    }
    public override void ExecuteTask()
    {
        taskManager.ExecuteNextTask();
    }
    private void OnDestroy()
    {
        if (jumpFrom)
        {
            Destroy(jumpFrom.gameObject);
        }        
    }
    public void SetInit(Transform _jumpFrom)
    {
        jumpFrom = _jumpFrom;
        transform.SetSiblingIndex(_jumpFrom.GetSiblingIndex());
    }
}
