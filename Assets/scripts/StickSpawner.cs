using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSpawner : MonoBehaviour
{
    public GameObject StickPrefab;

    public void CreateStick() 
    {
        GameObject.Instantiate(StickPrefab, transform);
    }
}
