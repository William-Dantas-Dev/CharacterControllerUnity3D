using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteAlways]
public class CameraController : MonoBehaviour
{
    public CharacterMovement CharacterMovement;
    public Transform CameraTarget;
    public float TargetHeight = 1f;
    public Vector2 XRotationRange = new Vector2(-50, 70);

    private Vector2 targetLook;
    public Quaternion LookRotation => CameraTarget.rotation;

    internal void IncrementLookRotation(Vector2 lookDelta)
    {
        targetLook += lookDelta;
        targetLook.x = Mathf.Clamp(targetLook.x, XRotationRange.x, XRotationRange.y);
    }

    private void LateUpdate()
    {
        CameraTarget.transform.position = CharacterMovement.transform.position + Vector3.up * TargetHeight;
        CameraTarget.transform.rotation = Quaternion.Euler(targetLook.x, targetLook.y, 0);
    }
}
