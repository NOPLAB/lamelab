using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScan : MonoBehaviour
{
    public (Vector3 hitPosition,GameObject hitObject) Shoot(Vector3 shootPosition,Vector3 shootForward)
    {
        Ray shootRay = new(shootPosition,shootForward);
        RaycastHit[] hits = new RaycastHit[10];
        int hitCount = Physics.RaycastNonAlloc(shootRay,hits);
        for(int i = 0;i < hitCount;i++)
        {
            if(hits[i].collider.CompareTag("Target"))
            {
                if(hits[i].collider.TryGetComponent<TargetHitHandler>(out var targetHitHandler))
                {
                    targetHitHandler.HitTarget();
                }
                
                return (hits[i].point,hits[i].collider.gameObject);
            }
        }
        return (Vector3.zero,null);
    }
}
