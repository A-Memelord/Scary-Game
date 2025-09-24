using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsDoorOpen = false;

    [SerializeField] public int requiredSwithchesToOpen = 1;
    [SerializeField] public SlideDoorManager SlideDoorManager;

    public int CurrentSwitchesOpen => currentSwitchesOpen.Count;

    public List<PressureSwitch> currentSwitchesOpen = new();
    
    public void AddPressureSwitch(PressureSwitch currentSwitch)
    {
        if(!currentSwitchesOpen.Contains(currentSwitch))
        {
            currentSwitchesOpen.Add(currentSwitch);
        }
        TryOpen();
    }

    public void RemovePressureSwitch(PressureSwitch currentSwitch)
    {
        if (currentSwitchesOpen.Contains(currentSwitch))
        {
            currentSwitchesOpen.Remove(currentSwitch);
        }
        TryOpen();
    }

    public void TryOpen()
    {
       if(CurrentSwitchesOpen >= requiredSwithchesToOpen)
        {
            OpenDoor();
        } else if(CurrentSwitchesOpen < requiredSwithchesToOpen)
        {
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        IsDoorOpen = true;
        if (!IsDoorOpen)
        {
            SlideDoorManager.OpenDoors();
            transform.GetComponent<Animator>().SetBool("Open", true);
            transform.GetComponent<Animator>().SetBool("Close", false);
        }
           
    }

    public void CloseDoor()
    {
        IsDoorOpen = false;
        if(IsDoorOpen)
        {
            SlideDoorManager.CloseDoors();
            transform.GetComponent<Animator>().SetBool("Close", true);
            transform.GetComponent<Animator>().SetBool("Open", false);
        }
        
    }
}
