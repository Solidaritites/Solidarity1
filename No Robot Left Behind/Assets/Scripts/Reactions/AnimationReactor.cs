using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReactor : Reactor
{
    public Animator ReactionAnimator;

    public Trigger[] AlternativeTriggers;

    public override void React()
    {
        ReactionAnimator.SetBool("Popup", true);
    }

    public override void Unreact()
    {
        bool released = true;
        if (AlternativeTriggers != null)
        {
            foreach (Trigger trigger in AlternativeTriggers)
            {
                if (trigger.Reacted)
                {
                    released = false;
                }
            }
        }
        if (released)
        {
            ReactionAnimator.SetBool("Popup", false);
        }
    }
}
