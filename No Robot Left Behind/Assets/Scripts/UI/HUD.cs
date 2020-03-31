using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public GameObject PausePanel;

    public void Restart()
    {
        GameManager.Instance.Restart();
    }

    public void NextLevel()
    {
        GameManager.Instance.NextLevel();
    }

    public void Dispose()
    {
        TextReactor[] TextReactors = GetComponentsInChildren<TextReactor>();
        foreach (TextReactor text in TextReactors)
        {
            text.gameObject.SetActive(false);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;

        PausePanel.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1;

        PausePanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
