using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [Tooltip("The common transform for the two lasers")][SerializeField] Transform laserContainerTransform; // Used instead of ship because of offset.
    [SerializeField] Camera cameraObject;
    [SerializeField] int rayTravelLength = 250;

    void Update()
    {
        Vector3 rayHit = laserContainerTransform.position + laserContainerTransform.forward * rayTravelLength;
        Debug.DrawLine(laserContainerTransform.position, rayHit, Color.blue);
        Vector3 viewPos = cameraObject.WorldToScreenPoint(rayHit);
        transform.position = viewPos;
    }
}
