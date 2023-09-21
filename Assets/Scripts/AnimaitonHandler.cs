using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaitonHandler : MonoBehaviour
{
    [SerializeField] private Animator _handAnimator;
    [SerializeField] private Animator _gunAnimator;

    public void PlayShootAnimation()
    {
        _handAnimator.Play("Shoot",0,0);
        _gunAnimator.Play("Shoot",0,0);
    }
}
