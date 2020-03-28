using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReactor : Reactor
{
    public Animator ReactionAnimator;

    public override void React()
    {
        ReactionAnimator.SetBool("Popup", true);
    }

    public override void Unreact()
    {
        ReactionAnimator.SetBool("Popup", false);
    }
}
