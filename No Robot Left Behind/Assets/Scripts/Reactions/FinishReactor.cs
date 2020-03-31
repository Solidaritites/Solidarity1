using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishReactor : Reactor
{
    public override void React()
    {
        GameManager.Instance.Win();
    }

    public override void Unreact()
    {

    }
}
