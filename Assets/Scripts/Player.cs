using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; //allow cross platform input controls

public class Player : MonoBehaviour
{
    [Tooltip("In meters/second")] [SerializeField] float xSpeed = 100f;
    [Tooltip("In meters/second")] [SerializeField] float ySpeed = 100f;
    [SerializeField] float xClampRange = 40f;
    [SerializeField] float yClampRange = 35f;
    [SerializeField] float positionPitchFactor = -0.4f;
    [SerializeField] float controlPitchFactor = -9f;

    [SerializeField] float positionYawFactor = -0.4f;

    [SerializeField] float controlRollFactor = -15f;

    float xThrow, yThrow;  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        handleHorizontalInput();
        handleVerticalInput();
        ProcessRotation();
    }

    void OnCollisionEnter(Collision collision)
    {
        print("player collided something");
    }

    void OnTriggerEnter(Collider other)
    {
        print("player triggered something");
    }

    private void ProcessRotation()
    {
        float pitchFromPosition = transform.localPosition.y * positionPitchFactor;
        float pitchFromControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchFromPosition + pitchFromControlThrow;

        float yaw = (transform.localPosition.x - xThrow) * positionYawFactor;


        float roll = controlRollFactor * xThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);  //used for rotation
    }

    private void handleHorizontalInput()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");  //horzontal position of joystick or if key pressed
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawNewXPos, -xClampRange, xClampRange);  //limit horizontal movement
        transform.localPosition = new Vector3(clampedXpos, transform.localPosition.y, transform.localPosition.z);
    }
    private void handleVerticalInput()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical"); //verticle position of joystick or if key pressed
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawNewYPos, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYpos, transform.localPosition.z);
    }
}