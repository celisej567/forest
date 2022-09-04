using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leave : MonoBehaviour
{
    public string MenuName;
    public void Выход() 
    {
        SceneManager.LoadScene(MenuName);   
    }
}
