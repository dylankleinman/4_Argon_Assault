using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; //allow cross platform input controls

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In meters/second")] [SerializeField] float xSpeed = 100f;
    [Tooltip("In meters/second")] [SerializeField] float ySpeed = 100f;
    [SerializeField] float xClampRange = 40f;
    [SerializeField] float yClampRange = 35f;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -0.4f;
    [SerializeField] float positionYawFactor = -0.4f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -9f;
    [SerializeField] float controlRollFactor = -15f;

    [SerializeField] GameObject[] Guns;

    float xThrow, yThrow;
    bool isControllEnabled = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isControllEnabled)
        {
            handleHorizontalInput();
            handleVerticalInput();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject element in Guns) //care may affect death FX!!
        {
            ParticleSystem gunBullets = element.GetComponent<ParticleSystem>();
            var gunBulletsEmission = gunBullets.emission;
            gunBulletsEmission.enabled = isActive;
        }
    }

    private void OnPlayerDeath() //called by string at CollisionHandler.cs
    {
        isControllEnabled = false;
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