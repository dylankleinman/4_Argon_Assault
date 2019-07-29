using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; //allow cross platform input controls

public class Player : MonoBehaviour
{
    [Tooltip("In meters/second")][SerializeField] float xSpeed = 4f;
    [Tooltip("In meters/second")] [SerializeField] float ySpeed = 4f;
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRange = 6f;
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

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    private void handleHorizontalInput()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawNewXPos, -xClampRange, xClampRange);
        transform.localPosition = new Vector3(clampedXpos, transform.localPosition.y, transform.localPosition.z);
    }
    private void handleVerticalInput()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawNewYPos, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYpos, transform.localPosition.z);
    }
}
