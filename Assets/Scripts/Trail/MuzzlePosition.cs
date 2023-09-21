using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzlePosition : MonoBehaviour
{
    [SerializeField] private Transform _muzzleTrans;

    public Transform GetMuzzleTrans()
    {
        return _muzzleTrans;
    }
}
