using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {
    public GameObject menuPanel;

	public void pauseGame()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }

    public void startGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Game");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
