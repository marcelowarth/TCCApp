using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ConveyorBelt : MonoBehaviour
{
    public List<GameObject> hardwareOnConveyor = new List<GameObject>();
    public Transform pointOfAccess;
}
