using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private float minFlickerSpeed = 0.1f;
    private float maxFlickerSpeed = 1.0f;
    private float timer;
    private float waitTimeSeconds = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Light>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Light>().enabled is false)
        {
            GetComponent<Light>().enabled = true;
            timer = 0.0f;
            waitTimeSeconds = Random.Range(minFlickerSpeed, maxFlickerSpeed);
            do
            {
                timer =+ 0.1f;
            }while(timer < waitTimeSeconds);
        }
        else
        {
            GetComponent<Light>().enabled = false;
            timer = 0.0f;
            waitTimeSeconds = Random.Range(minFlickerSpeed, maxFlickerSpeed);
            do
            {
                timer =+ 0.1f;
            }while(timer < waitTimeSeconds);
        }
    }
}
