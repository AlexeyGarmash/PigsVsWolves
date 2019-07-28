using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public static bool isGameEnd;
    // Update is called once per frame
    

    public GameObject gameoverUUI;


    public GameObject completeLevelUI;

    

    void Start()
    {
        isGameEnd = false;
    }
	void Update ()
    {
        if (isGameEnd) return;
		if(PlayerStats.Lives <= 0)
        {
            PlayerStats.Lives = 0;
            EndGame();
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
	}

    void EndGame()
    {
        isGameEnd = true;
        gameoverUUI.SetActive(true);
    }

    public void WinLevel()
    {

        isGameEnd = true;
        completeLevelUI.SetActive(true);


    }
}
