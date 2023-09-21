using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// BulletTrailによって弾のオブジェクトに付加

public class ReturnToPool : MonoBehaviour
{
    public IObjectPool<GameObject> _bulletPool;

    public void InactivateTrail()
    {
        // 表示を終えたこのオブジェクトをオブジェクトプールに返す
        ReleaseToPool();
        gameObject.SetActive(false);
    }

    private void ReleaseToPool()
    {
        if(_bulletPool == null)
        {
            print("error");
        }else
        {
            _bulletPool.Release(gameObject);
        }
    }

    public void SetBulletPool(IObjectPool<GameObject> bulletPool)
    {
        _bulletPool = bulletPool;
    }
}
