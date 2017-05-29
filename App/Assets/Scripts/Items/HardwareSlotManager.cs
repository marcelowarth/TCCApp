using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HardwareSlot
{
    public int hardwareValue;
    public int slotIndex;
}
public class HardwareSlotManager : MonoBehaviour
{
    public int slotsCount;
    public GameObject prefabSlot;
    public GameObject prefabHardware;
    public List<HardwareSlot> hardwaresToSpawn = new List<HardwareSlot>();

    private List<Slot> slots = new List<Slot>();

    private void Start()
    {
        SpawnSlots();
    }
    public Slot GetSlot(int index)
    {
        return slots[index];
    }
    private void SpawnSlots()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 1; i <= slotsCount; i++)
        {
            GameObject slot = Instantiate(prefabSlot, transform);
            slot.GetComponent<Slot>().SetSlotNumber(i);
            slots.Add(slot.GetComponent<Slot>());
        }
        SpawnHardwareToSlots();
    }
    private void SpawnHardwareToSlots()
    {
        for (int i = 0; i < slotsCount; i++)
        {
            for (int j = 0; j < hardwaresToSpawn.Count; j++)
            {
                if (i == hardwaresToSpawn[j].slotIndex)
                {
                    GameObject hardware = Instantiate(prefabHardware);
                    hardware.GetComponent<Hardware>().hardwareValue = hardwaresToSpawn[j].hardwareValue;
                    slots[i].SetHardwareToSlot(hardware);
                }
            }
        }
    }
    public void ResetSlotManager()
    {
        foreach (Slot slot in slots)
        {
            slot.DestroyHardwareOnSlot();
        }
        SpawnHardwareToSlots();
    }
}
