using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour {

    public SceneFader fader;

    public Button[] levelButons;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButons.Length; i++)
        {
            if ((i + 1) > levelReached)
            {
                levelButons[i].interactable = false;
            }
        }
    }

	public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
