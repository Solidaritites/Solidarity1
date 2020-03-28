using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public PlayerController Player;
    public CharacterController AllowedCharacter;

    private void Update()
    {
        foreach (CharacterController character in Player.Characters)
        {

        }
    }
}
