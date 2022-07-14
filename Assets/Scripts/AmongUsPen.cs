using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AmongUsPen : MonoBehaviour
{
    public AudioSource audioS;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.tag);
        if (other.CompareTag("Amongus"))
        {
            audioS.Play();
            GameManager.instance.ScoreInc();
            PlayHaptics();
        }
    }

    void PlayHaptics()
    {
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, devices);

        foreach (var device in devices)
        {
            HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0;
                    float amplitude = 0.5f;
                    float duration = 1.0f;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
    }
}
