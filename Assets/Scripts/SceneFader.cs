using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class SceneFader : MonoBehaviour
{

    public Image image;

    public AnimationCurve curve;

    private bool loadScene = false;

    public Text loadingText;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (loadScene == true)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
    }

    public void FadeTo(string scene)
    {
        loadScene = true;
        loadingText.text = "Loading...";
        StartCoroutine(FadeOut(scene));


    }


    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1f;
            float a = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        while (!async.isDone)
            yield return null;
    }

}
