using UnityEngine;

public class ObjectPushing : MonoBehaviour
{
    public float forceMagnitude;

    Rigidbody rb;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        rb = hit.collider.attachedRigidbody;

        if (rb != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Force);
        }
    }
}
