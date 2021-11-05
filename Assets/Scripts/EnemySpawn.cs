using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class EnemySpawn : MonoBehaviour
{
    private InputDevice targetDevice;
    public GameObject playerModel;
    public GameObject projectile;
    public Transform spawnPoint;
    public float shootingForce;

    private Vector3 playerSide;
    public Transform director;
    public Transform vrRig;

    public GameObject[] myObjects;
    public Transform[] positions;
    public float beat = 1;
    private float timer;
    public float enemyForce;

    private int count;

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

    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if (primaryButtonValue == true)
        {
            int randomObjectIndex = Random.Range(5, 9);
            int randomPosition = Random.Range(0, 4);
            if (timer > beat)
            {
                GameObject randomObject = Instantiate(myObjects[randomObjectIndex], positions[randomPosition]);
                randomObject.GetComponent<Rigidbody>().AddForce(0, 0, -enemyForce);

                timer -= beat;
            }
            timer += Time.deltaTime;
        }
        if (primaryButtonValue == false)
        {
            int randomObjectIndex = Random.Range(0, 4);
            int randomPosition = Random.Range(0, 4);
            if (timer > beat)
            {
                GameObject randomObject = Instantiate(myObjects[randomObjectIndex], positions[randomPosition]);
                randomObject.GetComponent<Rigidbody>().AddForce(0, 0, -enemyForce);

                timer -= beat;
            }
            timer += Time.deltaTime;
        }
    }
}
