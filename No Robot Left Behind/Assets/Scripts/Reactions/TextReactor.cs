using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextReactor : Reactor
{
    public Text text;
    public float Timer = 5;

    private void Update()
    {
        if (text.isActiveAndEnabled)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public override void React()
    {
        text.gameObject.SetActive(true);
    }

    public override void Unreact()
    {

    }
}
