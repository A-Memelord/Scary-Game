using System.Collections;
using UnityEngine;

public class sniper : MonoBehaviour
{
public GameObject bullet;
public GameObject target;
public GameObject sound;
private bool can_shoot = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position);
        if (can_shoot)
        {
            GameObject new_bullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            GameObject new_sound = Instantiate(sound, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            StartCoroutine(Reload());
        }
    }


    private IEnumerator Reload()
    {
        can_shoot = false;
        yield return new WaitForSeconds(4f);
        can_shoot = true;
    }
}
