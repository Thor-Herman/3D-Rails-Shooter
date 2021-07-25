using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _xSpeed = 25.0f;
    [SerializeField] private float _ySpeed = 20.0f;
    [SerializeField] private float _xRange = 15.0f;
    [SerializeField] private float _minYRange = -5.5f;
    [SerializeField] private float _maxYRange = 12f;

    [Header("Player Input-Based Rotation Tuning")]
    [SerializeField] private float controlPitchFactor = -15f;
    [SerializeField] private float controlRollFactor = -15f;

    [Header("Player Position-Based Rotation Tuning")]
    [SerializeField] private float positionPitchFactor = -1f;
    [SerializeField] private float positionYawFactor = 2.5f;

    [Tooltip("Add all player lasers here")][SerializeField] GameObject[] lasers;

    float horizontal, vertical;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float newXPos = transform.localPosition.x + horizontal * Time.deltaTime * _xSpeed;
        float newYPos = transform.localPosition.y + vertical * Time.deltaTime * _ySpeed;
        float clampedXPos = Mathf.Clamp(newXPos, -_xRange, _xRange);
        float clampedYPos = Mathf.Clamp(newYPos, _minYRange, _maxYRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = vertical * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float rollDueToControlThrow = horizontal * controlRollFactor;
        float roll = rollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire")) SetLasersActive(true);
        else SetLasersActive(false);
    }

    private void SetLasersActive(bool active)
    {
        foreach (GameObject laser in lasers)
        {
            ParticleSystem ps = laser.GetComponent<ParticleSystem>();
            if (ps == null) continue;
            ParticleSystem.EmissionModule emission = ps.emission; // Variable must be cached first
            emission.enabled = active;
        }
    }
}
