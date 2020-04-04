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

    public Transform groundCheck;
    private bool isGrounded;

    private void Start()
    {
        Tail = transform.position - transform.forward.normalized;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.layer != 8 && (hit.point - transform.position).sqrMagnitude < .9)
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

    public void ResetMovement()
    {
        MoveVector = Vector3.zero;
    }

    public void Move(Vector3 dir)
    {
        MoveVector += dir;
    }

    public void ApplyMovement()
    {
        MoveVector = MoveVector.sqrMagnitude > 1 ? MoveVector.normalized : MoveVector;
        Rigidbody.AddForce(MoveVector * Speed * Time.fixedDeltaTime * 700);
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