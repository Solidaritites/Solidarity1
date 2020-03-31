using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image Panel;

    private float Timer = 0;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        Panel.color = new Color(1,1,1,Timer / 8f);

        if (Timer > 10)
        {
            SceneManager.LoadScene(0);
        }
    }
}
