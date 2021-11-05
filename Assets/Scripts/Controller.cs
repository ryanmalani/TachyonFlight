using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Controller : MonoBehaviour
{
    private InputDevice targetDevice;
    public GameObject playerModel;
    public GameObject projectile;
    public Transform spawnPoint;
    public float shootingForce;
    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5;

    private Vector3 playerSide;
    public Transform director;
    public Transform vrRig;

    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

    }
    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
            Debug.Log("PressingPrimaryButton");
        
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.5f)
        {
            Debug.Log("Trigger pressed " + triggerValue);
            GameObject spawnProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            spawnProjectile.GetComponent<Rigidbody>().AddForce(playerModel.transform.forward * shootingForce);
            Destroy(spawnProjectile, 1f);
        }
        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if (primary2DAxisValue != Vector2.zero)
            Debug.Log("Axis is " + primary2DAxisValue);
        playerSide = director.right;
        playerSide.y = 0f;
        playerSide.Normalize();

        vrRig.Translate(-10*playerSide * primary2DAxisValue.x * Time.deltaTime, Space.Self);
    }
    
}