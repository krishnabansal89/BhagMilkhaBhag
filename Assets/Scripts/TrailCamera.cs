using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCamera : MonoBehaviour
{
    public Transform rb;
    public Transform cam;
    // public Vector3 pos;
    public Vector3 offset;
    public float damping;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 movePos = rb.position + offset;
      //  transform.Rotate(rb.transform.rotation);
        transform.position = Vector3.SmoothDamp(transform.position, movePos, ref velocity, damping);
    }
}