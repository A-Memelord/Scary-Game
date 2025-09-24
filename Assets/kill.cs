using UnityEngine;

public class kill : MonoBehaviour
{
    public GameObject die_ui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        die_ui = GameObject.Find("you died");
        print(die_ui);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            die_ui.GetComponent<youdied>().died();
        }
    }
}
