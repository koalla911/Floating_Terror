using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    private enum CameraMode 
    {
        Update,
        FixedUpdate,
        LateUpdate,

    }


    [Header("Target")]
    [SerializeField] private Transform targetTransform;

    [Header("Offset")]
    [SerializeField] private Vector2 offset;

    [Header("Mode")]
    [SerializeField] private CameraMode cameraMode = CameraMode.Update;

    public float smoothSpeed = 0.05f;

    private void Update() 
    {
        if (cameraMode == CameraMode.Update) 
        {
            FollowTarget();

        }

    }

    private void FixedUpdate() 
    {
        if (cameraMode == CameraMode.FixedUpdate) 
        {
            FollowTarget();

        }

    }

    private void LateUpdate() 
    {
        if (cameraMode == CameraMode.LateUpdate) 
        {
            FollowTarget();

        }        

    }

    private void FollowTarget() 
    {
        Vector3 desiredPosition = new Vector3(targetTransform.position.x + offset.x, targetTransform.position.y + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
