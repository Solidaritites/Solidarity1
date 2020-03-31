using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointReactor : Reactor
{
    public override void React()
    {
        GameManager.Instance.LastCheckpoint = this;
    }

    public override void Unreact()
    {

    }
}
