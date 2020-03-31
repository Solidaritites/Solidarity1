using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public PlayerController Player;

    private Vector3 Offset;
    private Vector3 Pos;

    private void Start()
    {
        Pos = transform.position;
        Offset = Pos;
    }

    private void Update()
    {
        if (Player.AllActive)
        {
            Pos = Vector3.zero;
            foreach (CharacterController character in Player.Characters)
            {
                Pos += character.transform.position;
            }
            Pos *= 1f / Player.Characters.Length;
            Pos += Offset;
        }
        else
        {
            Pos = Player.ActiveCharacter.transform.position + Offset;
        }
        transform.position = Vector3.Lerp(transform.position, Pos, Time.deltaTime * (Pos - transform.position).magnitude);
    }
}
