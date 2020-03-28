using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public PlayerController Player;

    private float Offset;
    private Vector3 Pos;

    private void Start()
    {
        Pos = transform.position;
        Offset = Pos.x;
    }

    private void Update()
    {
        float combinedX = 0;
        foreach (CharacterController character in Player.Characters)
        {
            combinedX += character.transform.position.x;
        }

        Pos.x = combinedX / 3 + Offset;
        transform.position = Pos;
    }
}
