using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public string levelNextName = "Level02";

    public int leveToUnlock = 2;

    

    public void Continue()
    {
        Debug.Log("Level WONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN!");
        PlayerPrefs.SetInt("levelReached", leveToUnlock);
        try
        {
            if (leveToUnlock > 3)
            {
                sceneFader.FadeTo("MainMenu");
                return;
            }
            sceneFader.FadeTo(levelNextName);
        }
        catch (UnityException ex)
        {
            sceneFader.FadeTo("MainMenu");
            PlayerPrefs.SetInt("levelReached", leveToUnlock - 1);
        }
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
