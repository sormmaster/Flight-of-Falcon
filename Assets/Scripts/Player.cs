using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    [Tooltip("In m/s")][SerializeField] float xSpeed = 15f;
    [Tooltip("In m")] [SerializeField] float xRange = 8f;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 15f;
    [Tooltip("In m")] [SerializeField] float yRange = 8f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -10f;
    [SerializeField] float controlPitchFactor = -10f;
    float xThrow;
    float ythrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
