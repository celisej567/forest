using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fireplace : MonoBehaviour
{
    public Light bbb;

    public float magnitude = 2;
    public float timer = 0.5f;

    private float time = 0;

    public float dietime = 1;

    public Slider Fuel;

    private void Start()
    {
        //bbb = GetComponent<Light>();
    }

    private void OnDrawGizmos()
    {
        //StartCoroutine("bebra");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            dietime += 0.3f * other.GetComponent<PlayerMovement>().stickCount;
            other.GetComponent<PlayerMovement>().stickCount = 0;
        }
    }

    void FixedUpdate()
    {

        dietime -= 0.001f;
        time += Time.deltaTime * timer * Random.Range(1,4);

        bbb.intensity = Mathf.Sin(time) * timer + 10 * dietime;
        Fuel.value = dietime;
        //Debug.Log(Fuel.value);
    }
}
