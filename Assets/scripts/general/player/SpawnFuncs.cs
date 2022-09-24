using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFuncs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsLevel"));
    }
}
