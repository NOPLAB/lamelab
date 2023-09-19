using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaitonHandler : MonoBehaviour
{
    [SerializeField] private Animator _handAnimator;
    [SerializeField] private Animator _gunAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayShootAnimation();
        }
    }

    public void PlayShootAnimation()
    {
        _handAnimator.Play("Shoot",0,0);
        _gunAnimator.Play("Shoot",0,0);
    }
}
