using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 1000 * Time.deltaTime;
    }
    private void Awake()
    {
        Destroy(gameObject, 10f);
    }
}
