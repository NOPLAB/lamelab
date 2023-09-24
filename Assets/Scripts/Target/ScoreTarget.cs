using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTarget : MonoBehaviour
{
    private TargetSpawner _targetSpawner;
    private int _index_X;
    private int _index_Y;

    public void SetSpawnerAndIndex(TargetSpawner targetSpawner,int index_X,int index_Y)
    {
        _targetSpawner = targetSpawner;
        _index_X = index_X;
        _index_Y = index_Y;
    }

    // イベントから呼ばれる
    public void OnHit()
    {
        _targetSpawner.OnDestroyTarget(_index_X,_index_Y);
        Destroy(gameObject);
    }
}
