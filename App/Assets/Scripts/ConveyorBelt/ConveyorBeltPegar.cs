using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltPegar : ConveyorBelt
{
    public GameObject prefabHardware;
    public List<int> hardwareToSpawn = new List<int>();

    private void Start()
    {
        SpawnHardwares();
    }
    public GameObject TakeHardware()
    {
        if (hardwareOnConveyor.Count > 0)
        {
            GameObject tmpHardware = hardwareOnConveyor[0];
            hardwareOnConveyor.RemoveAt(0);
            return tmpHardware;
        }
        return null;
    }
    void SpawnHardwares()
    {
        foreach (int value in hardwareToSpawn)
        {
            GameObject hardware = Instantiate(prefabHardware, transform);
            hardware.GetComponent<Hardware>().hardwareValue = value;
            hardware.transform.SetAsFirstSibling();
            hardwareOnConveyor.Add(hardware);
        }
    }
    public void ResetConveyor()
    {
        foreach (GameObject item in hardwareOnConveyor)
        {
            Destroy(item);
        }
        hardwareOnConveyor = new List<GameObject>();
        SpawnHardwares();
    }
}
