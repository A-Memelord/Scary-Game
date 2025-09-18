using System.Collections;
using UnityEngine;

public class fakesoundtravel : MonoBehaviour
{
    public AudioSource sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound.pitch = Random.Range(0.25f, 0.35f);
        StartCoroutine(playsound());
    }

    private IEnumerator playsound()
    {
        yield return new WaitForSeconds(2.3f);
        sound.Play();
    }
}
