using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsbutton : MonoBehaviour
{

    public void Load()
    {
        
        Time.timeScale = 1;
        StartCoroutine("load");
    }

    IEnumerable load()
    {
        SceneManager.LoadSceneAsync("settings");
        return null;
    }
}
