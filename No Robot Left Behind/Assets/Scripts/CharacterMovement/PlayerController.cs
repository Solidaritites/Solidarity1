using System;
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

    public bool AllActive { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)
                || Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                GameManager.Instance.HUD.Pause();
            }
            else if (GameManager.Instance.HUD.PausePanel.activeInHierarchy)
            {
                GameManager.Instance.HUD.Play();
            }
        }

        DetermineActiveCharacter();

        foreach (CharacterController character in Characters)
        {
            if (AllActive)
            {
                character.MeshRenderer.material.Lerp(character.DefaultMaterial, character.ActiveMaterial, Mathf.PingPong(Time.time, .3f));
            }
            else
            {
                character.MeshRenderer.material = character.DefaultMaterial;
            }
        }
        Characters[ActiveCharacterIdx].MeshRenderer.material.Lerp(Characters[ActiveCharacterIdx].DefaultMaterial, Characters[ActiveCharacterIdx].ActiveMaterial, Mathf.PingPong(Time.time, .3f));
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift)
            || Input.GetKey(KeyCode.RightShift))
        {
            foreach (CharacterController character in Characters)
            {
                DetermineCharacterMovement(character);
            }
            AllActive = true;
        }
        else
        {
            DetermineCharacterMovement(ActiveCharacter);
            AllActive = false;
        }
    }

    private void DetermineCharacterMovement(CharacterController character)
    {
        if (Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.A))
        {
            character.Move(Direction.Left);
        }
        if (Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.D))
        {
            character.Move(Direction.Right);
        }
        if (Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.W))
        {
            character.Move(Direction.Up);
        }
        if (Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.S))
        {
            character.Move(Direction.Down);
        }
    }

    private void DetermineActiveCharacter()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0
            || Input.GetKeyDown(KeyCode.E))
        {
            ActiveCharacterIdx += 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0
            || Input.GetKeyDown(KeyCode.Q))
        {
            ActiveCharacterIdx -= 1;
        }

        ActiveCharacterIdx =  (3 + ActiveCharacterIdx) % 3;
    }
}
