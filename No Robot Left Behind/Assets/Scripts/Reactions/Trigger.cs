using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Reactor[] Reactors;
    public int CharactersRequired = 1;

    private int CharactersActive;
    public bool Reacted { get; private set; }

    private void Update()
    {
        if (!Reacted && CharactersActive >= CharactersRequired)
        {
            Reacted = true;
            foreach (Reactor reactor in Reactors)
            {
                reactor.React();
            }
        }
        else if (Reacted && CharactersActive < CharactersRequired)
        {
            Reacted = false;
            foreach (Reactor reactor in Reactors)
            {
                reactor.Unreact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController character = other.GetComponent<CharacterController>();
        if (character != null)
        {
            CharactersActive += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterController character = other.GetComponent<CharacterController>();
        if (character != null)
        {
            CharactersActive -= 1;
        }
    }
}
