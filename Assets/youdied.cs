using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class youdied : MonoBehaviour
{
    public PlayerController Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void died()
    {
        gameObject.SetActive(true);
        Player.GetComponent<AudioSource>().Play();
        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = Player.checkpoint.transform.position;
        Player.GetComponent<CharacterController>().enabled = true;
    }
}
