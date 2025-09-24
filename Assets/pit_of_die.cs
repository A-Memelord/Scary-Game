using UnityEngine;

public class pit_of_die : MonoBehaviour
{
    public GameObject checkpoint;
    public youdied die_ui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            die_ui.died();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkpoint.transform.position, 1);
        Gizmos.DrawLine(transform.position, checkpoint.transform.position);
    }
}
