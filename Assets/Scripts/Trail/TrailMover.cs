using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMover : MonoBehaviour
{
    [SerializeField]
    private float _trailSpeed = 200;
    private ReturnToPool _returnToPool;
    private Vector3 _startPosiiton;
    private Vector3 _hitPosition;
    private float _startToHitDistance;
    private float _trailMoveTimer;

    void Start()
    {
        _returnToPool = gameObject.GetComponent<ReturnToPool>();
    }

    void Update()
    {
        _trailMoveTimer += Time.deltaTime;

        // 当たった位置に着くまで動かす
        if(_trailMoveTimer * _trailSpeed < _startToHitDistance)
        {
            gameObject.transform.position = Vector3.Lerp(_startPosiiton,_hitPosition,
                _trailMoveTimer * _trailSpeed / _startToHitDistance);

        }else if(Vector3.Distance(gameObject.transform.position,_hitPosition) > 0.1f)
        {
            gameObject.transform.position = _hitPosition;
            
        }else // 当たった位置に着いたら消す
        {
            _returnToPool.InactivateTrail();
        }
    }

    public void InitializeTrail(Vector3 startPosition,Vector3 hitPosition)
    {
        // 位置の設定とタイマーの初期化
        _startPosiiton = startPosition;
        _hitPosition = hitPosition;
        _startToHitDistance = Vector3.Distance(startPosition,hitPosition);
        _trailMoveTimer = 0;
    }
}
