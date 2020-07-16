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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHorizontal();
        UpdateVertical();
    }

    void UpdateHorizontal()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffSetOnFrame = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffSetOnFrame;
        float Clampedpos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(Clampedpos, transform.localPosition.y, transform.localPosition.z);
    }

    void UpdateVertical()
    {
        float ythrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yoffSetOnFrame = ythrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yoffSetOnFrame;
        float Clampedpos = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, Clampedpos, transform.localPosition.z);
    }
}
