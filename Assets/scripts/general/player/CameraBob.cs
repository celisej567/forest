using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    public bool Enable = true;
    [Range(0, 0.1f)] public float Amplitude = 0.015f;
    [Range(0, 30)] public float Frequency = 10;
    public float YStrength = 1;
    public float XStrength = 0.5f;
    public Transform Camera;
    public Transform CameraHolder;
    public float ToggleSpeed = 3;
    CharacterController controller;
    public bool IsRotating = false;

    Vector3 StartPos;
    Quaternion StartRot;

    private void Update()
    {
        if (Enable) 
        {
            CheckMotion();
            if (!IsRotating)
            {
                ResetPosition();
                CameraHolder.LookAt(FocusTarget());
            }
        }
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        StartPos = Camera.localPosition;
        StartRot = Camera.localRotation;
    }

    void PlayMotion(Vector3 motion) 
    {
        Camera.localPosition += motion;
    }

    void PlayMotion(Quaternion motion)
    {
        Camera.localRotation *= motion;
    }

    void CheckMotion()
    {

        if (controller.GetComponent<PlayerMovement>().PlayerState != PlayerMovement.CurrentState.Walk) return;
        if (!controller.isGrounded) return;

        if (!IsRotating)
            PlayMotion(FootStepMotion());
        else
            PlayMotion(FootStepRotation());
    }

    Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * Frequency) * Amplitude;
        pos.x += Mathf.Cos(Time.time * Frequency / 2) * Amplitude *2;
        return pos;
    }

    Quaternion FootStepRotation()
    {
        Quaternion pos = new Quaternion(0,0,0,0);
        pos.y += Mathf.Sin(Time.time * Frequency) * Amplitude;
        pos.x += Mathf.Cos(Time.time * Frequency / 2) * Amplitude * 2;
        return pos;
    }

    void ResetPosition()
    {
        if (!IsRotating)
        {
            if (Camera.localPosition == StartPos) return;
            Camera.localPosition = Vector3.Lerp(Camera.localPosition, StartPos, Time.deltaTime);
        }
        else
        {
            if (Camera.localRotation == StartRot) return;
        }
    }

    Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + CameraHolder.localPosition.y, transform.position.z);
        pos += CameraHolder.forward * 15;
        return pos;
    }


}
