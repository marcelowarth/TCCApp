using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPularTo : TaskBase
{
    public Text indexText;
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
    public void SetInit(Transform _jumpFrom, string indexLetter)
    {
        indexText.text = indexLetter;
        jumpFrom = _jumpFrom;
        transform.SetSiblingIndex(_jumpFrom.GetSiblingIndex());
    }
}
