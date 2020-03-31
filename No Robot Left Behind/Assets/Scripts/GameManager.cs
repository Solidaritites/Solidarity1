using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public PlayerController Player;
    public HUD HUD;
    public CheckpointReactor LastCheckpoint { get; set; }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    NextLevel();
        //}
    }

    public void Win()
    {
        Time.timeScale = 0;

        HUD.Dispose();

        HUD.WinPanel.SetActive(true);
    }

    internal void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        HUD.Dispose();

        HUD.GameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        if (LastCheckpoint != null)
        {
            Player.Characters[0].transform.position = LastCheckpoint.transform.position + new Vector3(3, 1, 0);
            Player.Characters[1].transform.position = LastCheckpoint.transform.position + new Vector3(-1.5f, 1, 2.598076f);
            Player.Characters[2].transform.position = LastCheckpoint.transform.position + new Vector3(-1.5f, 1, -2.598076f);

            Time.timeScale = 1;
            HUD.GameOverPanel.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
