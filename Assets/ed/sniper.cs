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
    public LayerMask layers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject.GetComponent<PlayerController>().moving == true)
        {
            transform.LookAt(aim_bot.transform.position);
        }
        else
        {
            transform.LookAt(target.transform.position);
        }
        if (Physics.Raycast(this.transform.position, target.transform.position - this.transform.position, out RaycastHit hitInfo, 999999f, layers))
        {
            if (hitInfo.transform.gameObject.CompareTag("Player") && can_shoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }


    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(Random.Range(2.2f, 4.5f));
        can_shoot = true;
    }

    private IEnumerator Shoot()
    {
        can_shoot = false;
        yield return new WaitForSeconds(Random.Range(1.2f, 3f));
        if (Physics.Raycast(this.transform.position, target.transform.position - this.transform.position, out RaycastHit hitInfo, 999999f, layers))
        {
            if (hitInfo.transform.gameObject.CompareTag("Player"))
            {
                GameObject new_bullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                GameObject new_sound = Instantiate(sound, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }
        }
        StartCoroutine(Reload());
    }
}
