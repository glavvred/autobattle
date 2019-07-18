using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform cameraObject;
    public float HorisontalSpeed;
    public float VerticalSpeed;
    public float ReturnTime;
    private float yaw, yawBase, pitch, pitchBase;
    private Quaternion startRotation, driftRotation;
    private bool isDrifting;
    private float driftTimer;

    private void Start()
    {
        startRotation = driftRotation = transform.rotation;

        pitch = pitchBase = transform.eulerAngles.x;
        yaw = yawBase = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(1))
        {
            startDrift();
        } else
        {
            if (isDrifting)
            {
                driftTimer += Time.deltaTime;
                if (driftTimer > ReturnTime)
                {
                    stopDrift();
                } else
                {
                    float ratio = driftTimer / ReturnTime;
                    transform.rotation = Quaternion.Slerp(driftRotation, startRotation, ratio);
                }
            }
        }

    }

    private void startDrift()
    {
        isDrifting = true;
        driftTimer = 0;

        yaw += HorisontalSpeed * Input.GetAxis("Mouse X");
        pitch -= VerticalSpeed * Input.GetAxis("Mouse Y");
        //the rotation range

        pitch = Mathf.Clamp(pitch, pitchBase - 5, pitchBase + 5);
        yaw = Mathf.Clamp(yaw, yawBase - 5, yawBase + 5);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0.0f);

        driftRotation = transform.rotation;
    }

    private void stopDrift()
    {
        isDrifting = false;
        transform.rotation = startRotation;
    }
}

