using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float rotateSpeed = 10f;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 10, 0)* rotateSpeed*Time.deltaTime);
    }
}