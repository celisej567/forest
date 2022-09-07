using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainstick : MonoBehaviour
{
    public fireplace Firething;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().stickCount += 1;
            GameObject.Destroy(gameObject);
            
        }
    }
}
