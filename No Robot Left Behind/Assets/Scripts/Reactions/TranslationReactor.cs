using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationReactor : Reactor
{
    public Vector3 Translation;
    public Vector3 Rotation;
    public Vector3 Scale = new Vector3(1,1,1);
    public float Duration;
    public float HoldTime;

    private Vector3 StartPos;
    private Vector3 EndPos;
    private Quaternion StartRot;
    private Quaternion EndRot;
    private Vector3 StartScale;
    private Vector3 EndScale;

    private float StartTime;
    private bool Reacted;
    private bool IsMoving;

    private bool Revert;

    private void Start()
    {
        StartPos = transform.position;
        EndPos = StartPos + Translation;
        StartRot = transform.rotation;
        EndRot = StartRot * Quaternion.Euler(Rotation);
        StartScale = transform.localScale;
        EndScale = new Vector3(StartScale.x * Scale.x, StartScale.y * Scale.y, StartScale.z * Scale.z);
    }

    private void Update()
    {
        float waitTime = Reacted ? Duration + HoldTime : Duration;

        if (IsMoving)
        {
            float percentageComplete = (Time.time - StartTime) / Duration;
            percentageComplete = percentageComplete > 1 ? 1 : percentageComplete;
            float lerpValue = (1 - Mathf.Cos(percentageComplete * Mathf.PI)) / 2;

            if (Reacted)
            {
                transform.position = Vector3.Lerp(StartPos, EndPos, lerpValue);
                transform.rotation = Quaternion.Lerp(StartRot, EndRot, lerpValue);
                transform.localScale = Vector3.Lerp(StartScale, EndScale, lerpValue);
            }
            else
            {
                transform.position = Vector3.Lerp(EndPos, StartPos, lerpValue);
                transform.rotation = Quaternion.Lerp(EndRot, StartRot, lerpValue);
                transform.localScale = Vector3.Lerp(EndScale, StartScale, lerpValue);
            }
        }
        if (Time.time > StartTime + waitTime)
        {
            IsMoving = false;
            if (Revert)
            {
                Revert = false;
                if (Reacted)
                {
                    Unreact();
                }
                else
                {
                    React();
                }
            }
        }
    }

    public override void React()
    {
        if (IsMoving)
        {
            Revert = !Reacted;
        }
        else
        {
            StartTime = Time.time;
            Reacted = true;
            IsMoving = true;
        }
    }

    public override void Unreact()
    {
        if (IsMoving)
        {
            Revert = Reacted;
        }
        else
        {
            StartTime = Time.time;
            Reacted = false;
            IsMoving = true;
        }
    }
}