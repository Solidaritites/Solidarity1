using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject RaycastCollider;
    public Camera Camera;
    public CharacterController[] Characters;
    public CharacterController ActiveCharacter
    {
        get
        {
            return Characters[ActiveCharacterIdx];
        }
    }
    private int ActiveCharacterIdx;
    private Vector3 RaycastColliderPos;

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
        Vector3 pos = (Characters[0].transform.position + Characters[1].transform.position + Characters[2].transform.position) / 3f;

        if (Input.GetKey(KeyCode.LeftShift)
            || Input.GetKey(KeyCode.RightShift)
            || Input.GetMouseButton(0))
        {
            RaycastColliderPos.y = pos.y - 1;
            foreach (CharacterController character in Characters)
            {
                DetermineCharacterMovement(character, pos - Vector3.down);
            }
            AllActive = true;
        }
        else
        {
            RaycastColliderPos.y = Characters[ActiveCharacterIdx].transform.position.y - 1;
            DetermineCharacterMovement(ActiveCharacter, ActiveCharacter.transform.position - Vector3.down);
            AllActive = false;
        }
        RaycastCollider.transform.position = RaycastColliderPos;
    }

    private void DetermineCharacterMovement(CharacterController character, Vector3 controlPoint)
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
            RaycastHit hit;
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000000, LayerMask.GetMask("RobotPlane1")))
            {
                character.Move(hit.point - controlPoint);
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
