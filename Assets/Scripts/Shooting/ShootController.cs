using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MuzzlePosition),typeof(ShootScan))]

public class ShootController : MonoBehaviour
{
    private Transform _muzzleTrans;
    private AnimaitonHandler _animaitonHandler;
    private BulletTrail _bulletTrail;
    private ShootScan _shootScan;
    private Transform _cameraTrans;

    // Start is called before the first frame update
    void Start()
    {
        _muzzleTrans = gameObject.GetComponent<MuzzlePosition>().GetMuzzleTrans();
        _animaitonHandler = transform.root.GetComponent<AnimaitonHandler>();
        _bulletTrail = GameObject.FindWithTag("BulletTrail").GetComponent<BulletTrail>();
        _shootScan = gameObject.GetComponent<ShootScan>();
        _cameraTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _animaitonHandler.PlayShootAnimation();
            var scanResult = _shootScan.Shoot(_cameraTrans.position,_cameraTrans.forward);
            if(scanResult.hitObject != null)
            {
                _bulletTrail.ShootTrailedBullet(_muzzleTrans.position,scanResult.hitPosition);
            }else
            {
                _bulletTrail.ShootTrailedBullet(_muzzleTrans.position,Camera.main.transform.forward * 100);
            }   
        }
    }
}
