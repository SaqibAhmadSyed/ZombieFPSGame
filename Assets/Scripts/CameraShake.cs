using DG.Tweening;
using System;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private CinemachineImpulseSource shake;
    [SerializeField]
    private float strength;

    public void ShakeCam(Vector3 dir)
    {
        shake.GenerateImpulseWithVelocity(dir);
    }
}
