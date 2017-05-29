using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TaskPularFrom : TaskBase
{
    public GameObject prefabJumpTo;
    public GameObject prefabArrow;
    public GameObject loopArrow;
    public Transform jumpTo;

    private Transform mainCanvas;
    
    public new void Start()
    {
        base.Start();
        mainCanvas = GameObject.Find("MainCanvas").transform;        
    }

    public void Update()
    {
        if (bIsAtTaskArea)
        {
            if (!jumpTo)
            {
                jumpTo = Instantiate(prefabJumpTo, transform.parent).transform;
                jumpTo.GetComponent<TaskPularTo>().SetInit(transform);
            }
        }
    }

    public override void ExecuteTask()
    {
        taskManager.ExecuteTask(jumpTo.GetSiblingIndex());
    }

    public virtual void OnDestroy()
    {
        if(jumpTo)
        {
            Destroy(jumpTo.gameObject);
        }
    }
}
