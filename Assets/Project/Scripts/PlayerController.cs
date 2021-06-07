using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _xSpeed = 20.0f, _ySpeed = 15.0f, _xRange = 6f, _minYRange = -3f, _maxYRange = 7f,
    positionPitchFactor = -3f, controlPitchFactor = -10f, positionYawFactor = 3.5f, controlRollFactor = -13f;
    float horizontal, vertical;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
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
}
