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
    Vector3 StartPos;
    CharacterController controller;

    private void Update()
    {
        if (Enable) 
        {
            CheckMotion();
            ResetPosition();
            CameraHolder.LookAt(FocusTarget());
        }
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        StartPos = Camera.localPosition;
    }

    void PlayMotion(Vector3 motion) 
    {
        Camera.localPosition += motion;
    }

    void CheckMotion()
    {

        if (controller.GetComponent<PlayerMovement>().PlayerState != PlayerMovement.CurrentState.Walk) return;
        if (!controller.isGrounded) return;
        PlayMotion(FootStepMotion());
    }

    Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * Frequency) * Amplitude;
        pos.x += Mathf.Cos(Time.time * Frequency / 2) * Amplitude *2;
        return pos;
    }

    void ResetPosition()
    {
        if (Camera.localPosition == StartPos) return;
        Camera.localPosition = Vector3.Lerp(Camera.localPosition, StartPos, Time.deltaTime);
    }

    Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + CameraHolder.localPosition.y, transform.position.z);
        pos += CameraHolder.forward * 15;
        return pos;
    }
}
