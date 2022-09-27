using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    public int MaxLevelSticks; 
    [HideInInspector] public GameObject[] SticksInWorld;
    [HideInInspector] public GameObject[] stickSpawner;
    StickSpawner bebra;

    public Fireplace fireplace;

    [Header("Lose things")]
    public GameObject LoseImage;
    public Vector2 LoseImageStartScale;
    public Quaternion LoseImageStartRotation;
    public bool LoseStarted = false;
    public Vector2 LoseImageStopScale;
    public Quaternion LoseImageStopRotation;
    public AudioClip LoseAudio;

    void Start()
    {
        stickSpawner = GameObject.FindGameObjectsWithTag("Spawner");
        
    }

    private void FixedUpdate()
    {
        //check if world have enough sticks
        SticksInWorld = GameObject.FindGameObjectsWithTag("stick");
        if (MaxLevelSticks > SticksInWorld.Length) 
        {
            stickSpawner[Random.Range(0, stickSpawner.Length)].GetComponent<StickSpawner>().CreateStick();
        }

        //check if fireplace is die
        if(fireplace.dietime < 0)
        {
            if (!LoseStarted)
            {
                LoseStarted = true;
                LoseImage.SetActive(true);
                LoseImage.transform.localScale = LoseImageStartScale;
                LoseImage.transform.rotation = LoseImageStartRotation;
                AudioSource bb = gameObject.AddComponent<AudioSource>();
                bb.clip = LoseAudio;
                bb.Play();
            }
        }

        if(LoseStarted)
        {
            LoseImage.transform.localScale = Vector2.Lerp(LoseImage.transform.localScale, LoseImageStopScale, Time.deltaTime);
            LoseImage.transform.rotation = Quaternion.Lerp(LoseImage.transform.rotation, LoseImageStopRotation, Time.deltaTime);
        }
    }
}
