using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class sniper : MonoBehaviour
{
public GameObject bullet;
public GameObject target;
public GameObject aim_bot;
public GameObject sound;
private bool can_shoot = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (can_shoot)
        {
            if (target.gameObject.GetComponent<PlayerController>().moving == true)
            {
                transform.LookAt(aim_bot.transform.position);
            }
            else
            {
                transform.LookAt(target.transform.position);
            }
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
