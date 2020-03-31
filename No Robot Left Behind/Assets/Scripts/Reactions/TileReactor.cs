using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileReactor : Reactor
{
    public int AllowedCharacterIdx = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (AllowedCharacterIdx == -1 || other.transform != GameManager.Instance.Player.Characters[AllowedCharacterIdx].transform)
        {
            GameManager.Instance.GameOver();
        }
    }

    public override void React()
    {

    }

    public override void Unreact()
    {

    }
}
