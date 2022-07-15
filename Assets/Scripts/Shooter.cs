using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Shooter : MonoBehaviour
{
    public float timeBetweenShots = 1;

    private float timeUntilNextShot;
    private bool canShoot = true;

    public int layerMask = 6;

    public float force;

    private void Start()
    {
        layerMask = 1 << layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeUntilNextShot)
        {
            canShoot = true;
        }
        if (canShoot)
        {
            // Get the device assigned to the right hand
            InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            // Check if the trigger of the device is pressed
            bool triggerValue;
            if (rightHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                // shoot raycast
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
                {
                    Debug.Log("Hit" + hit);
                    hit.rigidbody.AddRelativeForce(Vector3.back * force);
                }
                else
                {
                    Debug.Log("Did not Hit");
                }

                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShots;
            }
        }
    }
}