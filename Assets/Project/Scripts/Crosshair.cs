using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [Tooltip("The transform for the laser")][SerializeField] Transform laserTransform; // Used instead of ship because of offset.
    [SerializeField] Camera cameraObject;
    [SerializeField] int rayTravelLength = 100;

    void Update()
    {
        Vector3 rayHit = laserTransform.position + laserTransform.forward * rayTravelLength;
        Debug.DrawLine(laserTransform.position, rayHit, Color.blue);
        Vector3 viewPos = cameraObject.WorldToScreenPoint(rayHit);
        transform.position = viewPos;
    }
}
