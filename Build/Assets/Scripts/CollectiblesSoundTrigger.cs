using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesSoundTrigger : MonoBehaviour
{
    [SerializeField]
    AudioSource source;
    public bool IsAvailable = true;
    [SerializeField]// Add your Audi Clip Here;
    BoxCollider soundTrigger;
    public float soundCooldown = 3f;
    
    // MAke Sure You added AudioSouce to death Zone;
    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<BoxCollider>();
    }
    void Start()
    {
        /*GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = saw;*/
        /*timeStamp = Time.time + soundCooldown;*/
    }
   
  

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (IsAvailable == true)
            {
                source.Play();
                StartCoroutine(StartCooldown());
            }
            
            
            
        } 
    }

    public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(soundCooldown);
        IsAvailable = true;
    }
}

