using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public void Exit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
