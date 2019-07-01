using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //What object the camera will be following
    public Transform target;

    //How much the camera will smooth/lag behind
    public float smoothSpeed = 0.125f;

    //Camera Offset
    public Vector3 offset;

    // Same as Update but its just called after the other updates
    //This was directly from the tutorial I was watching
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}