using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltLevar : ConveyorBelt
{
    public List<int> hardwareToReceive = new List<int>();
    public bool bReceivedAllHardware = false;
	public void LeaveHardware(GameObject hardware)
    {
        if(hardwareToReceive[hardwareOnConveyor.Count] == hardware.GetComponent<Hardware>().hardwareValue)
        {
            GameObject newHardware = Instantiate(hardware, transform);
            hardwareOnConveyor.Add(newHardware);
            Destroy(hardware);
            if(hardwareOnConveyor.Count == hardwareToReceive.Count)
            {
                bReceivedAllHardware = true;
            }
        }
        else
        {
            int X = hardwareToReceive[hardwareOnConveyor.Count];
            int Y = hardware.GetComponent<Hardware>().hardwareValue;
            Speaker.Inst.SetMessageAndColor("ERRADO! Era esperado " + X +", mas colocaste " + Y + "!", Speaker.MessageType.Error);
        }
    }
    public void ResetConveyor()
    {
        foreach (GameObject item in hardwareOnConveyor)
        {
            Destroy(item);
        }
        hardwareOnConveyor = new List<GameObject>();
    }
}
