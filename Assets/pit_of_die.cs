using UnityEngine;

public class pit_of_die : MonoBehaviour
{
    public GameObject checkpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = checkpoint.transform.position;
        }
    }
}
