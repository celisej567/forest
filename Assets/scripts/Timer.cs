using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public float StartFromTime = 0;
    public bool IsCountdown = false;
    public float Speed = 1;

    float currentTime;
    void Start()
    {
        if (StartFromTime != 0)
            currentTime = StartFromTime;
    }

    // Update is called once per frame
    void Update()
    {

        currentTime += IsCountdown ? -Time.deltaTime : Time.deltaTime;
        currentTime = (float)System.Math.Round(currentTime, 2);
        GetComponent<Text>().text = currentTime.ToString();
    }
}
