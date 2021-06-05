using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _xSpeed = 20.0f, _ySpeed = 15.0f, _xRange = 6f, _minYRange = -3f, _maxYRange = 7f;
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float newXPos = transform.localPosition.x + horizontal * Time.deltaTime * _xSpeed;
        float newYPos = transform.localPosition.y + vertical * Time.deltaTime * _ySpeed;
        float clampedXPos = Mathf.Clamp(newXPos, -_xRange, _xRange);
        float clampedYPos = Mathf.Clamp(newYPos, _minYRange, _maxYRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

    }
}
