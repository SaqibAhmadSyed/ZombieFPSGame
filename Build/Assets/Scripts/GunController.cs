using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Gun gun;

    [SerializeField]
    private string enemyTag;
    private StarterAssetsInputs input;
    private bool fire;

    private void Start()
    {
        input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        if (input.shoot)
        {
            fire = true;

        } else
        {
            fire = false;
        }
        if (fire)
        {
            gun.Fire(enemyTag);

            if (gun.UseTap())
            {
                fire = false;
            }
        }
    }
}
