using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "MainLevel";

    public SceneFader sceneFader;
	public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Settings()
    {
        sceneFader.FadeTo("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
