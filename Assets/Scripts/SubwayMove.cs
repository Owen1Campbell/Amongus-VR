using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SubwayMove : MonoBehaviour
{
    public float[] lane = new float[3];
    int laneIndex;
    public float timeUntilNextMove;
    private bool canMove = true;
    private float moveTimer;

    // Start is called before the first frame update
    void Start()
    {
        laneIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            // adds move cooldown, prevents switching 2 lanes with one joystick flick
            if (moveTimer >= timeUntilNextMove)
            {
                canMove = true;
                moveTimer = 0;
            }
            else
            {
                moveTimer += Time.deltaTime;
            }
        }

        InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        // Check if the trigger of the device is pressed
        Vector2 value;
        if (rightHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out value))
        {
            if (value.x != 0 || value.y != 0)
                Debug.Log(value);
            // if joystick moves left and the player is not already in the leftmost lane, move left
            if (value.x <= -0.5f && laneIndex > 0 && canMove)
            {
                ChangeLane(-1);
            }
            else if (value.x >= 0.5f && laneIndex < 2 && canMove)
            {
                ChangeLane(1);
            }
        }
    }

    void ChangeLane(int inc)
    {
        // send a +1 or -1 to this function
        // moves laneIndex up or down based on input
        laneIndex += inc;

        // move player to corresponding x
        transform.position = new Vector3(lane[laneIndex], transform.position.y, transform.position.z);
        canMove = false;
    }
}
