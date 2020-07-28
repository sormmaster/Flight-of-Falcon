using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovementController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In m/s")][SerializeField] float xSpeed = 25f;
    [Tooltip("In m")] [SerializeField] float xRange = 15f;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 25f;
    [Tooltip("In m")] [SerializeField] float yRange = 10f;

    [Header("Screen Position")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Local Movement")]
    [SerializeField] float controlRollFactor = -10f;
    [SerializeField] float controlPitchFactor = -5f;
    float xThrow;
    float ythrow;
    bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        UpdateHorizontal();
        UpdateVertical();
        Rotation();
    }

    void Rotation()
    {
        float pitchByPosition = transform.localPosition.y * positionPitchFactor;
        float pitchByThrow = ythrow * controlPitchFactor;
        float pitch = pitchByPosition + pitchByThrow;

        float rollByThrow = xThrow * controlRollFactor;
        float yawByPosition = transform.localPosition.x * positionYawFactor;

        float yaw = yawByPosition;
        float roll = rollByThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void UpdateHorizontal()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffSetOnFrame = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffSetOnFrame;
        float Clampedpos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(Clampedpos, transform.localPosition.y, transform.localPosition.z);
    }

    void UpdateVertical()
    {
        ythrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yoffSetOnFrame = ythrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yoffSetOnFrame;
        float Clampedpos = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, Clampedpos, transform.localPosition.z);
    }

    void OnPlayerDeath()
    {
        isDead = true;
    }

    //End of Script
}
