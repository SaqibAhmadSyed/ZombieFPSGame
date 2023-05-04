using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float fireRate;

    [SerializeField]
    private float fireDistance = 10;

    [SerializeField]
    private Transform bulletPoint;

    private RaycastHit hit;

    private bool cooldown;

    public void Fire(string enemyTag)
    {
        if (cooldown) return;

        Ray ray = new Ray();
        ray.origin = bulletPoint.position;
        ray.direction = bulletPoint.TransformDirection(Vector3.forward);

        Debug.DrawRay(ray.origin, ray.direction * fireDistance, Color.green);

        if (Physics.Raycast(ray, out hit, fireDistance))
        {
            if (hit.collider.CompareTag(enemyTag))
            {
                var healthCtrl = hit.collider.GetComponent<HealthController>();
                healthCtrl.ApplyDamage(damage);
            }
        }

        cooldown = true;
        StartCoroutine(StopCooldownAfterTime());
    }

    private IEnumerator StopCooldownAfterTime()
    {
        yield return new WaitForSeconds(fireRate);
        cooldown = false;
    }

    public bool UseTap()
    {
        return fireRate == 0;
    }
}
