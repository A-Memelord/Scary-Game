using Unity.VisualScripting;
using UnityEngine;

public class hit : MonoBehaviour
{
    public AudioSource sound;
    public bullet bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.layer);
        if (other.gameObject.layer == 7)
        {
            sound.Play();
            bullet.Light.intensity = 0;
            bullet.speed = 0;
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
