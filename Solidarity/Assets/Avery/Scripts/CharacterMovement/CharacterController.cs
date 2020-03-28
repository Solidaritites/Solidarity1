using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed = 5;
    public Rigidbody Rigidbody;

    private Vector3 MoveVector;

    public void Move(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                MoveVector = Vector3.forward * Speed * Time.fixedDeltaTime;
                break;
            case Direction.Down:
                MoveVector = -Vector3.forward * Speed * Time.fixedDeltaTime;
                break;
            case Direction.Left:
                MoveVector = -Vector3.right * Speed * Time.fixedDeltaTime;
                break;
            case Direction.Right:
                MoveVector = Vector3.right * Speed * Time.fixedDeltaTime;
                break;
            default:
                break;
        }
        
        Rigidbody.AddForce(MoveVector * 500);
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}