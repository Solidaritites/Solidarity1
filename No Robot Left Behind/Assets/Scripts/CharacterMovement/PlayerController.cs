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
    private Vector3 PreviousMousePos;
    private Vector3 MousePos;

    public bool AllActive { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MousePos = Input.mousePosition;
            MousePos.z = MousePos.y;
            MousePos.y = 0;
            PreviousMousePos = Input.mousePosition;
            PreviousMousePos.z = PreviousMousePos.y;
            PreviousMousePos.y = 0;
        }

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
            || Input.GetKey(KeyCode.RightShift)
            || Input.GetMouseButton(0))
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
        bool usingKeys = false;

        character.ResetMovement();

        if (Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.A))
        {
            character.Move(Vector3.left);
            usingKeys = true;
        }
        if (Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.D))
        {
            character.Move(Vector3.right);
            usingKeys = true;
        }
        if (Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.W))
        {
            character.Move(Vector3.forward);
            usingKeys = true;
        }
        if (Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.S))
        {
            character.Move(Vector3.back);
            usingKeys = true;
        }
        if (!usingKeys && Input.GetMouseButton(1))
        {
            MousePos = Input.mousePosition;
            MousePos.z = MousePos.y;
            MousePos.y = 0;
            character.Move(MousePos - PreviousMousePos);
            if ((MousePos - PreviousMousePos).sqrMagnitude != 0)
            {
                PreviousMousePos = MousePos;
            }
        }

        character.ApplyMovement();
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
