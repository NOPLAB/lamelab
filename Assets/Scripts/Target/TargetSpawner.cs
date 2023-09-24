using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // 全てfalse、的を生成したindexをtrueにする
    private List<List<bool>> _targetsList;
    private int _size_X = 10;
    private int _size_Y = 5;

    [SerializeField] private GameObject _target;
    private int targetCount = 3;
    private int _allTargetCount = 15;
    private int _AlliveTargetCount;

    [SerializeField] private SoundEffector _soundEffector;
    // イベントから
    public void Spawn15Target()
    {
        _AlliveTargetCount = _allTargetCount;

        // トランスフォームの子を「なぜか」全取得できる
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        _targetsList = new List<List<bool>>(_size_X);

        for(int i = 0;i < _size_X;i++)
        {
            _targetsList.Add(new List<bool>());

            for(int i2 = 0;i2 < _size_Y;i2++)
            {
                _targetsList[i].Add(false);
            }
        }
        
        for(int i = 0;i < targetCount;i++)
        {
            SpawnTarget();
        }
    }

    private void SpawnTarget()
    {
        if(_AlliveTargetCount <= 0)
        {
            return;
        }

        for(int i = 0;i < _size_X*_size_Y;i++)
        {
            int index_X = Random.Range(0,_size_X);
            int index_Y = Random.Range(0,_size_Y);

            if(!_targetsList[index_X][index_Y])
            {
                _targetsList[index_X][index_Y] = true;
                GameObject target = Instantiate(_target,transform);
                ScoreTarget scoreTarget = target.GetComponent<ScoreTarget>();
                scoreTarget.SetSpawnerAndIndex(this,index_X,index_Y);
                SetTargetPosition(target.transform,index_X,index_Y);

                _AlliveTargetCount--;
                target.GetComponent<TargetHitHandler>()._event.AddListener(_soundEffector.Play);
                break;
            }
        }
    }

    private void SetTargetPosition(Transform targetTrans,int index_X,int index_Y)
    {
        targetTrans.localPosition = new Vector3(
            (index_X - _size_X / 2) * 0.1f,
            (index_Y - _size_Y / 2) * 0.1f + 1.6f,
            3f
        );
    }

    // ターゲットヒット時に呼ぶ
    public void OnDestroyTarget(int index_X,int index_Y)
    {
        _targetsList[index_X][index_Y] = false;
        SpawnTarget();
    }
}
