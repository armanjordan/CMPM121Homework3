using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// original source code: https://answers.unity.com/questions/34739/how-to-make-a-light-flicker.html by user duck
// Source code modified by Dylan De La Cerda

public class FlickerLight : MonoBehaviour
{
    private float timeMin = 0.5f; //minimum time for being on (maximum time for being off)
    private float timeMax = 1.0f; //maximum time for being on
    private float offMin = 0.1f; //minimum time for being off
    private float changeTime = 0.0f; //variable used to help with comparing to the in-game time

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > changeTime) //if the in-game time passes a certain time
        {
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled; //enable or disable the light depending on the context
            if (GetComponent<Light>().enabled) //if on
            {
                changeTime = Time.time + Random.Range(timeMin, timeMax); //sets time on to be minimum timeMin and maximum timeMax
            }
            else //if off
            {
                changeTime = Time.time + Random.Range(offMin, timeMin); //sets time off to be minimum offMin and maximum timeMin
            }
        }
    }
}
