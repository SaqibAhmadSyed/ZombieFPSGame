using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs input;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    private float nextTimeToFire;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject origin;

    [SerializeField]
    CameraShake recoilShake;

    // Start is called before the first frame update
    void Start()
    {
        input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            StartCoroutine(StartRecoil());
            Shoot();
        }
    }

    IEnumerator StartRecoil()
    {
        this.GetComponent<Animator>().Play("Recoil");
        yield return new WaitForSeconds(0.25f);
        this.GetComponent<Animator>().Play("New State");
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(origin.transform.position, origin.transform.forward, out hit, range))
        {
            Ray ray = new(Camera.main.transform.position, Camera.main.transform.forward);
            recoilShake.ShakeCam(ray.direction);
            Debug.DrawLine(origin.transform.position, hit.point, Color.red, 10f);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
            
        }

    }
}
