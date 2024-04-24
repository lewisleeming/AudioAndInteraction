using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHands : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;

    public Renderer nonPhysicshands;
    public float showNonPhysicsHandsDistance = 0.05f;

    private bool _isGrabbed = false;

    private Collider[] hColliders;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        hColliders = GetComponentsInChildren<Collider>();

    }

    void Update() {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > showNonPhysicsHandsDistance)
        {
            nonPhysicshands.enabled = true;
        }
        else
        nonPhysicshands.enabled = false;
    }

    void FixedUpdate() {

        //physics hands positioning
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        // physics hands rotation

        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegrees = angleInDegrees * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime);

    }

    public void EnableColliderDelay (float delay)
    {
        _isGrabbed = false;
        Invoke(nameof(EnableColliders), delay);
    }

    public void EnableColliders()
    {
        if(!_isGrabbed)
        {
            foreach (var item in hColliders)
        {
            item.enabled = true;
        }
        }
        
    
    }

    public void DisableColliders()
    {
        _isGrabbed = true;
         foreach (var item in hColliders)
        {
            item.enabled = false;
        }
    
    }
}
