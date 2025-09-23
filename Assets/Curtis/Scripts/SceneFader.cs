using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image image;

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    private void FadeAndLoad(string sceneName, float duration)
    {
        StartCoroutine(Fader(sceneName, duration));
    }

    IEnumerator Fader(string sceneName, float duration)
    {
        float t = 0;
        Color c = image.color;
        while(t < duration)
        {
            t += Time.deltaTime;
            c.a = 4f - (t / 4f);
            image.color = c;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeOut()
    {
        float t = 0;
        Color c = image.color;
        while (t < 4)
        {
            t += Time.deltaTime;
            c.a = 4f - (t / 1f);
            image.color = c;
            yield return null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            FadeAndLoad("SceneB", 1);
        }
    }


}
