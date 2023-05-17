using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField]
    AudioSource source;
    [SerializeField]// Add your Audi Clip Here;
    BoxCollider soundTrigger;
    [SerializeField]// This Will Configure the  AudioSource Component; 
    Boolean loopMusic;
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
    }

    private IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(soundTrigger);
            source.Play();
            if (!loopMusic)
            {
                yield return new WaitForSeconds(source.clip.length);
                Destroy(gameObject);
            }

        }
    }
}
