using UnityEngine;
using UnityEngine.Events;

public class PressureSwitch : MonoBehaviour
{
    [SerializeField] public GameObject currentDoor;
    public Animator anim;


    public UnityEvent OnOpen;
        public UnityEvent OnClose;
    public void OnTriggerEnter(Collider other)
    {
        print("Trigger Entered");
        currentDoor.GetComponent<Door>().AddPressureSwitch(this);
        anim.SetBool("Open", true);
        OnOpen.Invoke();
    }

    public void OnTriggerExit(Collider other)
    {
        print("Trigger Exited");
        currentDoor.GetComponent<Door>().RemovePressureSwitch(this);
        anim.SetBool("Open", false);
        OnClose.Invoke();
    }
}
