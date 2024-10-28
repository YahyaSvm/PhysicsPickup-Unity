// Created by yahyasvm. All rights reserved.
// Forked and developed by samhogan on GitHub.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    public float dist = 2.5f;
    public float rotationSpeed = 100f;
    public float minDist = 1f;
    public float maxDist = 5f;

    private GameObject curObject;
    private Rigidbody curBody;
    private Quaternion relRot;
    private bool isHolding = false;

    public bool allowVerticalMovement = false; // Allow vertical movement

    void Update()
    {
        // Pickup/drop with left mouse click
        if (Input.GetMouseButton(0))
        {
            if (curObject == null)
            {
                PickupItem();
            }
            else
            {
                ReposObject();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DropItem();
        }

        // Rotate with R key
        if (isHolding && Input.GetKey(KeyCode.R))
        {
            RotateObject();
            LockCameraAndPlayerRotation();
        }

        // Zoom in/out with mouse movement
        if (isHolding)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                dist = Mathf.Clamp(dist - scroll, minDist, maxDist);
                ReposObject();
            }
        }
    }

    void FixedUpdate()
    {
        if (curObject != null && isHolding)
        {
            ReposObject();
        }
    }

    void ReposObject()
    {
        Vector3 targetPos = transform.position + transform.forward * dist;

        // Check for vertical movement allowance
        if (!allowVerticalMovement)
        {
            targetPos.y = curBody.position.y; // Keep the object fixed in the Y-axis
        }

        Quaternion targetRot = transform.rotation * relRot;
        curBody.velocity = (targetPos - curBody.position) * 10;
        curBody.rotation = targetRot;
        curBody.angularVelocity = Vector3.zero;
    }

    void PickupItem()
    {
        RaycastHit hitInfo;
        Physics.Raycast(transform.position, transform.forward, out hitInfo, 5f);

        if (hitInfo.rigidbody == null)
            return;

        curBody = hitInfo.rigidbody;
        curBody.useGravity = false;
        curObject = hitInfo.rigidbody.gameObject;

        curObject.transform.parent = transform;
        relRot = curObject.transform.localRotation;
        curObject.transform.parent = null;

        isHolding = true; // Update item holding status
    }

    void DropItem()
    {
        if (curBody != null)
        {
            curBody.useGravity = true;
        }

        curBody = null;
        curObject = null;
        isHolding = false; // Update item dropping status
    }

    void RotateObject()
    {
        float rotateX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float rotateY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        curObject.transform.Rotate(Vector3.up, -rotateX);
        curObject.transform.Rotate(Vector3.right, rotateY);
    }

    void LockCameraAndPlayerRotation()
    {
        // Lock player and camera rotation
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Reset Y axis
        cameraForward.Normalize();

        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = targetRotation; // Lock player rotation
    }
}
