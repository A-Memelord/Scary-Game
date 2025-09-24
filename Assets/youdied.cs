using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class youdied : MonoBehaviour
{
    public PlayerController Player;
    public GameObject image;
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
        image.SetActive(true);
        Player.GetComponent<AudioSource>().Play();
        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = Player.checkpoint.transform.position;
        Player.GetComponent<CharacterController>().enabled = true;
        StartCoroutine(lol());
    }
    private IEnumerator lol()
    {
        yield return new WaitForSeconds(2.5f);
        image.SetActive(false);
        Player.GetComponent<CharacterController>().enabled = true;
    }
}
