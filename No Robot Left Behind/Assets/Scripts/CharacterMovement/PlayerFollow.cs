using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public PlayerController Player;
    public Camera Camera;

    private Vector3 Offset;
    private Vector3 Pos;
    private Vector3 CameraZoomOut;

    private void Start()
    {
        Pos = transform.position;
        Offset = Pos;
        CameraZoomOut = new Vector3(0, 0, -20);
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

            Camera.transform.localPosition = Vector3.Lerp(Camera.transform.localPosition, CameraZoomOut, Time.deltaTime * (CameraZoomOut - Camera.transform.localPosition).magnitude);
        }
        else
        {
            Pos = Player.ActiveCharacter.transform.position + Offset;

            Camera.transform.localPosition = Vector3.Lerp(Camera.transform.localPosition, Vector3.zero, Time.deltaTime * Camera.transform.localPosition.magnitude);
        }
        transform.position = Vector3.Lerp(transform.position, Pos, Time.deltaTime * (Pos - transform.position).magnitude);
    }
}
