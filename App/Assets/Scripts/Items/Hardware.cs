using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hardware : MonoBehaviour
{
    public int hardwareValue;
    public Text textNumber;

    private void Start()
    {
        textNumber.text = hardwareValue.ToString();
    }
    private void Update()
    {
        textNumber.text = hardwareValue.ToString();
    }

    public void IncreaseValue()
    {
        hardwareValue++;
    }

    public void DecreaseValue()
    {
        hardwareValue--;
    }
    public void AddValue(int value)
    {
        hardwareValue += value;
    }

    public void DiminishValue(int value)
    {
        hardwareValue -= value;
    }

    
}
