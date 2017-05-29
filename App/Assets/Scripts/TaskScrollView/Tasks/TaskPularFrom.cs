using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class TaskPularFrom : TaskBase
{
    public GameObject prefabJumpTo;
    public GameObject prefabArrow;
    public GameObject loopArrow;
    public Transform jumpTo;
    public Text indexText;
    private Transform mainCanvas;
    [HideInInspector]
    public string indexLetter;
    
    public new void Start()
    {
        base.Start();
        mainCanvas = GameObject.Find("MainCanvas").transform;
        indexText.transform.parent.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (bIsAtTaskArea)
        {
            if (!jumpTo)
            {
                indexText.transform.parent.gameObject.SetActive(true);
                indexLetter = taskManager.GetIndexLetter();
                indexText.text = indexLetter.ToString();
                jumpTo = Instantiate(prefabJumpTo, transform.parent).transform;
                jumpTo.GetComponent<TaskPularTo>().SetInit(transform, indexLetter);
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
