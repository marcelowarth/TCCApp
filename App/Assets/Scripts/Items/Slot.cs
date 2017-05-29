using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Text slotNumber;
    public Transform hardwareSlot;
    private int slotIndex;
    private GameObject hardware;
    private TaskManager taskManager;
    private void Start()
    {
        taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
    }
    public void SetSlotNumber(int number)
    {
        slotIndex = number - 1;
        slotNumber.text = number.ToString();
    }
    public void CopyHardwareToSlot(GameObject _hardware)
    {
        if (hardware)
        {
            Destroy(hardware);
        }
        hardware = Instantiate(_hardware, hardwareSlot);
    }
    public void SetHardwareToSlot(GameObject _hardware)
    {
        if (hardware)
        {
            Destroy(hardware);
        }
        hardware = Instantiate(_hardware, hardwareSlot);
        Destroy(_hardware);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(taskManager.managerState == TaskManager.ManagerState.SelectingSlot)
        {
            taskManager.SendSlotIndex(slotIndex);
        }
    }
    public GameObject GetHardwareOnSlot()
    {
        return hardware;
    }
    public void DestroyHardwareOnSlot()
    {
        if (hardware)
        {
            Destroy(hardware);
        }
        hardware = null;
    }
}
