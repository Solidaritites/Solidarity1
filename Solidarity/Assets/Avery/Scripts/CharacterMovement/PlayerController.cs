using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController[] Characters;
    public CharacterController ActiveCharacter
    {
        get
        {
            return Characters[ActiveCharacterIdx];
        }
    }
    private int ActiveCharacterIdx;

    private void Update()
    {
        DetermineActiveCharacter();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (CharacterController character in Characters)
            {
                DetermineCharacterMovement(character);
            }
        }
        else
        {
            DetermineCharacterMovement(ActiveCharacter);
        }
    }

    private void DetermineCharacterMovement(CharacterController character)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            character.Move(Direction.Left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            character.Move(Direction.Right);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            character.Move(Direction.Up);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            character.Move(Direction.Down);
        }
    }

    private void DetermineActiveCharacter()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActiveCharacterIdx = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ActiveCharacterIdx = 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ActiveCharacterIdx = 2;
        }
    }
}
