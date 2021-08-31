using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Camera camera;
    [SerializeField] int rayTravelLength = 250;

    Plane plane;

    void Start()
    {
        plane = new Plane();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayHit = playerTransform.position + playerTransform.forward * rayTravelLength;
        Debug.DrawLine(playerTransform.position, rayHit, Color.red);
        // plane.SetNormalAndPosition(camera.transform.forward, camera.transform.position);
        Vector3 planeHit = plane.ClosestPointOnPlane(rayHit);
        // Vector3 cameraPlane = camera.transform.position + camera.farClipPlane * camera.transform.forward;
        // Vector3 planeHit = Vector3.ProjectOnPlane(rayHit, camera.transform.position);
        Debug.DrawLine(camera.transform.position, camera.transform.position + camera.farClipPlane * camera.transform.forward, Color.green);
        Debug.DrawLine(playerTransform.position, planeHit, Color.blue);
        Vector3 viewPos = camera.WorldToScreenPoint(planeHit);
        transform.position = viewPos;
    }
}
