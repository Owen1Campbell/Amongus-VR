using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public GameObject follow;
    public float followSpeed = 30.0f;
    public float rotateSpeed = 50.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Physics setup
        rb = GetComponent<Rigidbody>();
        rb.position = follow.transform.position + positionOffset;
        rb.rotation = follow.transform.rotation * Quaternion.Euler(rotationOffset);

    }

    // Update is called once per frame
    void Update()
    {
        PhysicsTransform();
    }

    // Move hand with physics
    private void PhysicsTransform()
    {
        // Position
        Vector3 followPosOffset = follow.transform.position + positionOffset;
        float dist = Vector3.Distance(followPosOffset, transform.position);
        rb.velocity = (followPosOffset - transform.position).normalized * (followSpeed * dist);

        // Rotation
        Quaternion followRotOffset = follow.transform.rotation * Quaternion.Euler(rotationOffset);
        Quaternion quat = followRotOffset * Quaternion.Inverse(rb.rotation);
        float angle;
        Vector3 axis;
        quat.ToAngleAxis(out angle, out axis);
        rb.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }
}