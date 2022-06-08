using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class TriggerButtonEvent : UnityEvent<bool> { }

public class BaseGun : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public GameObject grab_front;

    //GrabFront script
    private GrabFront grabFront;

    //sound clips
    public AudioClip fireSound;
    public AudioClip reloadSound;
    public AudioClip emptySound;

    //private inputDevices
    private TriggerButtonEvent triggerButtonEvent;
    private bool lastButtonState = false;
    private List<InputDevice> inputDevices;

    // Start is called before the first frame update
    void Start()
    {
        //detect grabfront script from grab_front object
        grabFront = grab_front.GetComponent<GrabFront>();

        if (triggerButtonEvent == null)
        {
            triggerButtonEvent = new TriggerButtonEvent();
        }

        inputDevices = new List<InputDevice>();
    }

    void OnEnable() {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach(InputDevice device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        inputDevices.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out discardedValue))
        {
            inputDevices.Add(device); // Add any devices that have a primary button.
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (inputDevices.Contains(device))
            inputDevices.Remove(device);
    }

    // Update is called once per frame
    void Update()
    {
        /*bool triggerValue;
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            if (triggerValue && grabFront.isGrabbing)
            {
                Shoot();
            } else if (triggerValue && !grabFront.isGrabbing)
            {
                Debug.Log("You need to grab the gun first!");

                //play empty sound
                AudioSource.PlayClipAtPoint(emptySound, transform.position);
            }
        }*/

        bool tempState = false;
        foreach (var device in inputDevices)
        {
            bool triggerState = false;
            tempState = device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerState) // did get a value
                        && triggerState // the value we got
                        || tempState; // cumulative result from other controllers
        }

        if (tempState != lastButtonState) // Button state changed since last frame
        {
            triggerButtonEvent.Invoke(tempState);
            lastButtonState = tempState;
            

            if (tempState)
            {
                if (grabFront.isGrabbing)
                {
                    Shoot();
                }
                else
                {
                    Debug.Log("You need to grab the gun first!");

                    //play empty sound
                    AudioSource.PlayClipAtPoint(emptySound, transform.position);
                }
            }
        }
    }

    public void Shoot()
    {
        Debug.Log("Shoot");

        //play sound
        AudioSource.PlayClipAtPoint(fireSound, transform.position);

        //create bullet
        GameObject bullet = Instantiate(bulletPrefab, Spawnpoint.position, Spawnpoint.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(Spawnpoint.forward * bulletSpeed);
    }
}
