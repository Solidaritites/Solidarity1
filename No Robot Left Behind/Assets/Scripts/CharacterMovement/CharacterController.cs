using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed = 5;
    public Rigidbody Rigidbody;

    public GameObject Model;

    public Material DefaultMaterial;
    public Material ActiveMaterial;

    public MeshRenderer MeshRenderer;

    private Vector3 MoveVector;

    private Vector3 Tail;

    private void Start()
    {
        Tail = transform.position - transform.forward.normalized;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        int layermask = LayerMask.GetMask("Default");

        if (Physics.Raycast(ray, out hit) && (hit.point - transform.position).sqrMagnitude < .9)
        {
            transform.position = hit.point + Vector3.up.normalized;
        }

        Vector3 tailDistance = Tail - transform.position;
        Tail = Vector3.Lerp(Tail, transform.position, (tailDistance.magnitude - .25f) * Time.deltaTime * 2);
        if (tailDistance.sqrMagnitude < .25 * .25)
        {
            Tail = transform.position + tailDistance.normalized * .25f;
        }
        Tail.y = transform.position.y;
        tailDistance = Tail - transform.position;

        if (Model != null)
        {
            Model.transform.LookAt(transform.position - tailDistance);
            Model.transform.Rotate(new Vector3(10 - 15 * (tailDistance.magnitude - .25f), 0, 0));
        }
    }

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, Tail);
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}