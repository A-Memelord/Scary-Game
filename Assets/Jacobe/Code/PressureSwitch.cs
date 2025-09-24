using UnityEngine;
using UnityEngine.Events;

public class PressureSwitch : MonoBehaviour
{
    [SerializeField] public GameObject currentDoor;


    public UnityEvent OnOpen;
        public UnityEvent OnClose;
    public void OnTriggerEnter(Collider other)
    {
        print("Trigger Entered");
        currentDoor.GetComponent<Door>().AddPressureSwitch(this);
        OnOpen.Invoke();
    }

    public void OnTriggerExit(Collider other)
    {
        print("Trigger Exited");
        currentDoor.GetComponent<Door>().RemovePressureSwitch(this);
        OnClose.Invoke();
    }
}
