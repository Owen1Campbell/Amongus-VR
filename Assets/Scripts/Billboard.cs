using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Vector3 dir;
    // Update is called once per frame
    void Update()
    {
        // copy form main camera
        dir = Camera.main.transform.forward;
        // y stays constant
        dir.y = 0;
        // apply to transform
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
