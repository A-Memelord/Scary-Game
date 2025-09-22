using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsDoorOpen = false;

    [SerializeField] private int requiredSwithchesToOpen = 1;
    [SerializeField] private SlideDoorManager SlideDoorManager;

    private int CurrentSwitchesOpen => currentSwitchesOpen.Count;

    private List<PressureSwitch> currentSwitchesOpen = new();
    
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

    private void TryOpen()
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
        }
           
    }

    public void CloseDoor()
    {
        IsDoorOpen = false;
        if(IsDoorOpen)
        {
            SlideDoorManager.CloseDoors();
        }
        
    }
}
