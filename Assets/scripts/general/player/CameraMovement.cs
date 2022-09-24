using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    [Header("Main")]
    public float MouseSens = 200f;
    float xRot;
    public GameObject PlayerBody;
    public int MaxCameraAngle = 80;

    bool pause = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -MaxCameraAngle, MaxCameraAngle);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        PlayerBody.transform.Rotate(Vector3.up * mouseX);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            GameRules gr = GameObject.FindObjectOfType<GameRules>();

            if(gr.LoseStarted)
            {
                StartCoroutine("Restart");
                return;
            }

            if (!pause)
            {
                Cursor.lockState = CursorLockMode.Confined;
                pause = true;
                StartCoroutine("PauseGame");
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                pause = false;
                StartCoroutine("UnPauseGame");
            }
        }
    }

    IEnumerator PauseGame()
    {
        SceneManager.LoadSceneAsync("pause", LoadSceneMode.Additive);
        Time.timeScale = 0;
        return null;
    }

    IEnumerator UnPauseGame()
    {
        SceneManager.UnloadSceneAsync("pause");
        Time.timeScale = 1;
        return null;
    }

    IEnumerator Restart()
    {
        SceneManager.UnloadSceneAsync("game");
        SceneManager.LoadSceneAsync("game");
        return null;
    }


}
