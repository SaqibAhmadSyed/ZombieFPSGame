using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CollectFirstAid : MonoBehaviour
{
    public ParticleSystem DestructionEffect;
    public float firstAidCooldown = 3f;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            // GameManager.Instance.FirstAidCollected();
            Invoke("SetTrue", firstAidCooldown);
            Explode();
        }


    }

    void SetTrue()
    {
        gameObject.SetActive(true);
    }


    void Explode()
    {
        //Instantiate our one-off particle system
        ParticleSystem explosionEffect = Instantiate(DestructionEffect)
                                         as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        //play it

        explosionEffect.Play();

        //destroy the particle system when its duration is up, right
        //it would play a second time.

        Destroy(explosionEffect.gameObject, 3);
        gameObject.SetActive(false);

    }
}
