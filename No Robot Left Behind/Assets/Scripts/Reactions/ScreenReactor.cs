using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenReactor : Reactor
{
    public GameObject screen;
    public float Timer = 5;
    private float OriginalTimer;

    private void Start()
    {
        OriginalTimer = 5;
    }

    private void Update()
    {
        if (screen.activeInHierarchy)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                screen.gameObject.SetActive(false);
                Timer = OriginalTimer;
            }
        }
    }

    public override void React()
    {
        screen.gameObject.SetActive(true);
    }

    public override void Unreact()
    {

    }
}
