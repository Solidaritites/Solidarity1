using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoundReactor : Reactor
{
    public Reactor[] Reactors;

    private int idx;

    public override void React()
    {
        if (idx < Reactors.Length)
        {
            Reactors[idx].React();
            idx += 1;
        }
    }

    public override void Unreact()
    {

    }
}
