using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private double timeOn = 0.1;
    private double timeOff = 0.5;
    private double changeTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > changeTime)
        {
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
            if (GetComponent<Light>().enabled) 
            {
                changeTime = Time.time + timeOn;
            }
            else
            {
            changeTime = Time.time + timeOff;
            }
        }
    }
}
