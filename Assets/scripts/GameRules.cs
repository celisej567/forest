using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    public int MaxLevelSticks; 
    [HideInInspector] public GameObject[] SticksInWorld;
    [HideInInspector] public GameObject[] stickSpawner;
    StickSpawner bebra;
    void Start()
    {
        stickSpawner = GameObject.FindGameObjectsWithTag("Spawner");
        
    }

    private void FixedUpdate()
    {
        SticksInWorld = GameObject.FindGameObjectsWithTag("stick");
        if (MaxLevelSticks > SticksInWorld.Length) 
        {
            stickSpawner[Random.Range(0, stickSpawner.Length)].GetComponent<StickSpawner>().CreateStick();
        }   
    }
}
