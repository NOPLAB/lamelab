using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// BulletTrailタグを付けた空のオブジェクトにアタッチ、シーンに初めから置いておく

public class BulletTrail : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;

    public ObjectPool<GameObject> bulletPool;
    private int _maxPoolSize = 15;
    public bool collectionChecks = true;



    // Start is called before the first frame update
    private void Start()
    {
        bulletPool = new ObjectPool<GameObject>
            (CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                OnDestroyPoolObject, collectionChecks, 10, _maxPoolSize);
    }

    private GameObject CreatePooledItem()
    {
        GameObject bullet = Instantiate(_bullet,Vector3.zero,Quaternion.identity,gameObject.transform);
        ReturnToPool returnToPool = bullet.AddComponent<ReturnToPool>();

        returnToPool.SetBulletPool(bulletPool);
        return bullet;
    }

    public void OnTakeFromPool(GameObject bullet)
    {
        
    }

    public void OnReturnedToPool(GameObject bullet)
    {
        
    }

    public void OnDestroyPoolObject(GameObject bullet)
    {
        Destroy(bullet);
    }

    public void ShootTrailedBullet(Vector3 startPosition,Vector3 hitPosition)
    {
        GameObject _bullet = bulletPool.Get();
        _bullet.transform.position = startPosition;
        TrailRenderer trailRenderer = _bullet.GetComponent<TrailRenderer>();
        trailRenderer.Clear();
        _bullet.SetActive(true);
        TrailMover trailMover = _bullet.GetComponent<TrailMover>();
        trailMover.InitializeTrail(startPosition,hitPosition);
    }
}
