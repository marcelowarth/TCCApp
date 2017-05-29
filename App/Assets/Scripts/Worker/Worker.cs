using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour
{
    public ConveyorBeltPegar conveyorPegar;
    public ConveyorBeltLevar conveyorLevar;
    public Canvas hardwareSlot;
    public HardwareSlotManager slots;

    private GameObject carryingHardware;

    private NavMeshAgent agent;
    private Animator anim;
    private SpriteRenderer sprite;
    private Vector3 startPosition;
    private float defaultStoppingDistance;
    private void Start()
    {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        defaultStoppingDistance = agent.stoppingDistance;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0f, 0f);
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        if (carryingHardware)
        {
            anim.SetBool("bIsCarryingHardware", true);
        }
        else
        {
            anim.SetBool("bIsCarryingHardware", false);
        }
        anim.SetFloat("Speed", Vector3.Distance(Vector3.zero, agent.velocity));
        if(agent.velocity.x > 0f)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        agent.isStopped = false;
        agent.SetDestination(destination);
    }

    public bool IsWorkerAtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void TakeHardwareOnConveyor()
    {
        GameObject tmpGameObject = conveyorPegar.TakeHardware();
        if (tmpGameObject)
        {
            if (carryingHardware)
            {
                Destroy(carryingHardware);
            }
            carryingHardware = Instantiate(tmpGameObject, hardwareSlot.transform);
            Destroy(tmpGameObject);
        }
        else
        {
            Speaker.Inst.SetMessageAndColor("Não é possível realizar a operação em uma posição vazia!", Speaker.MessageType.Error);
        }
    }
    public void LeaveHardwareOnConveyor()
    {
        if (carryingHardware)
        {
            conveyorLevar.LeaveHardware(carryingHardware);
        }
        else
        {
            Speaker.Inst.SetMessageAndColor("Este comando não pode ser realizado de mãos vazias!", Speaker.MessageType.Error);
        }
    }
    public void ResetCharacter()
    {
        Destroy(carryingHardware);
        agent.isStopped = true;
        transform.position = startPosition;
        Destroy(carryingHardware);
        carryingHardware = null;
    }
    public void StopCharacter()
    {
        agent.isStopped = true;
    }
    public void CopyTo(Slot slot)
    {
        if (carryingHardware)
        {
            slot.CopyHardwareToSlot(carryingHardware);
        }
        else
        {
            Speaker.Inst.SetMessageAndColor("Este comando não pode ser realizado de mãos vazias!", Speaker.MessageType.Error);
        }
    }
    public void CopyFrom(Slot slot)
    {
        if (slot.GetHardwareOnSlot())
        {
            if (carryingHardware)
            {
                Destroy(carryingHardware);
            }
            carryingHardware = Instantiate(slot.GetHardwareOnSlot(), hardwareSlot.transform);
        }
        else
        {
            Speaker.Inst.SetMessageAndColor("Não é possível realizar a operação em uma posição vazia!", Speaker.MessageType.Error);
        }
    }
    public void IncreaseSlotHardwareValue(Slot slot)
    {
        if (slot.GetHardwareOnSlot())
        {
            slot.GetHardwareOnSlot().GetComponent<Hardware>().IncreaseValue();
        }
        else
        {
            Speaker.Inst.SetMessageAndColor("Não é possível realizar a operação em uma posição vazia!", Speaker.MessageType.Error);
        }
    }
    public void DecreaseSlotHardwareValue(Slot slot)
    {
        if (slot.GetHardwareOnSlot())
        {
            slot.GetHardwareOnSlot().GetComponent<Hardware>().DecreaseValue();
        }
        else
        {
            Speaker.Inst.SetMessageAndColor("Não é possível realizar a operação em uma posição vazia!", Speaker.MessageType.Error);
        }
    }
    public void IncreaseCarryingHardwareValue(Slot slot)
    {
        if (slot.GetHardwareOnSlot() && carryingHardware)
        {
            carryingHardware.GetComponent<Hardware>().AddValue(slot.GetHardwareOnSlot().GetComponent<Hardware>().hardwareValue);
        }
        else
        {
            Speaker.Inst.SetMessageAndColor("Este comando não pode ser realizado de mãos vazias!", Speaker.MessageType.Error);
        }
    }
    public void DecreaseCarryingHardwareValue(Slot slot)
    {
        if (slot.GetHardwareOnSlot() && carryingHardware)
        {
            carryingHardware.GetComponent<Hardware>().DiminishValue(slot.GetHardwareOnSlot().GetComponent<Hardware>().hardwareValue);
        }
        else
        {
            Speaker.Inst.SetMessageAndColor("Este comando não pode ser realizado de mãos vazias!", Speaker.MessageType.Error);
        }
    }

    public void SetStoppingDistance(float distance)
    {
        agent.stoppingDistance = distance;
    }
    public void ResetStoppingDistance()
    {
        agent.stoppingDistance = defaultStoppingDistance;
    }

    public Hardware GetCarryingHardware()
    {
        if (carryingHardware)
        {
            return carryingHardware.GetComponent<Hardware>();
        }
        return null;
    }
}
