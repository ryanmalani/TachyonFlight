using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ProjectileSpawner : MonoBehaviour
{

    // Properties
    public GameObject projectile;
    public Transform position;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            GameObject spawnProjectile = Instantiate(projectile, position);
            projectile.transform.localPosition = Vector3.zero;
            projectile.transform.Translate(transform.forward);
        }
    }
}
