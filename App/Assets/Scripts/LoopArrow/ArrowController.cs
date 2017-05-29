using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowController : MonoBehaviour
{
    public RectTransform bodyRect;
    public RectTransform tipRect;
    public RectTransform originRect;

    private RectTransform pularFromRect;
    private RectTransform pularToRect;
    private RectTransform mainRect;
    private bool bHasInitialized = false;

	void Start ()
    {
        mainRect = GetComponent<RectTransform>();
    }
	
	void Update ()
    {
        if (bHasInitialized)
        {
            mainRect.sizeDelta = new Vector2(mainRect.sizeDelta.x, VerticalDistance(pularFromRect.position, pularToRect.position) + 100f);
            mainRect.anchoredPosition = new Vector2(mainRect.sizeDelta.x / 2, Mathf.Abs(mainRect.sizeDelta.y / 2));

        }
	}
    private void OnDestroy()
    {
        
    }

    public void InitArrowController(RectTransform from, RectTransform to)
    {
        bHasInitialized = true;
        pularFromRect = from;
        pularToRect = to;
    }

    float HorizontalDistance(Vector2 a, Vector2 b)
    {
        return Mathf.Abs(b.x - a.x);
    }
    float VerticalDistance(Vector2 a, Vector2 b)
    {
        return Mathf.Abs(b.y - a.y);
    }
}
