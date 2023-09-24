using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 弾に当たり動作するオブジェクトに共通してアタッチ

public class TargetHitHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _event;

    // 弾が当たるとShootScanから呼ばれる
    public void OnHit()
    {
        _event.Invoke();
    }
}
