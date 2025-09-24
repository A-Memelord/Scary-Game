using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    public Light Light;
    public AudioSource bang;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(lesslight());
    }

    private IEnumerator lesslight()
    {
        yield return new WaitForSeconds(0.2f);
        Light.intensity = 20f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bang.pitch = Random.Range(2.5f, 3f);
            bang.Play();
        }
    }


    private void Awake()
    {
        Destroy(gameObject, 10f);
    }

}
