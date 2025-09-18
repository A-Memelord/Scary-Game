using UnityEngine;

public class Crouching : MonoBehaviour
{
    public CharacterController Playerheight;
    public CapsuleCollider PlayerCol;
    public float normalheight, crouchheight;
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Playerheight.height = crouchheight;
            PlayerCol.height = crouchheight;
        }
        
        if (Input.GetKeyUp(KeyCode.C))
        {
            Playerheight.height = normalheight;
            PlayerCol.height = normalheight;
            player.position = player.position + offset;
        }


    }
}
