using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAvatar : MonoBehaviour
{
    public Animator animator;

    public void Squish()
    {
        animator.Play("BallAvatarSquish");
    }

    public void Squash()
    {
        animator.Play("BallAvatarSquash");
    }
}
