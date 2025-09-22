using UnityEngine;
public class SlideDoorManager : MonoBehaviour
{
    [SerializeField] private Door[] Doors;


    [ContextMenu("Open")]
    public void OpenDoors()
    {
        foreach (var Door in Doors)
        {
            Door.OpenDoor();
        }
    }
    public void CloseDoors()
    {
        foreach (var Door in Doors)
        {
            Door.CloseDoor();
        }
    }
}