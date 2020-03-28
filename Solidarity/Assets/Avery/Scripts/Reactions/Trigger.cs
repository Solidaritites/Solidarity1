using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Reactor[] Reactors;

    private void OnTriggerEnter(Collider other)
    {
        CharacterController character = other.GetComponent<CharacterController>();
        if (character != null)
        {
            foreach (Reactor reactor in Reactors)
            {
                reactor.React();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterController character = other.GetComponent<CharacterController>();
        if (character != null)
        {
            foreach (Reactor reactor in Reactors)
            {
                reactor.Unreact();
            }
        }
    }
}
