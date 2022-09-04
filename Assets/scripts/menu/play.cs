using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
   
    public void Load()
    {
        StartCoroutine("load");
    }

    IEnumerable load()
    {
        SceneManager.LoadScene("game");
        return null;
    }
}
