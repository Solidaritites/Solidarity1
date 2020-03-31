using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathReactor : Reactor
{
    public override void React()
    {
        GameManager.Instance.GameOver();
    }

    public override void Unreact()
    {

    }
}
