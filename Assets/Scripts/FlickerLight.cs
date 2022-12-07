using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private float timeMin = 0.5f;
    private float timeMax = 1.0f;
    private float offMin = 0.1f;
    private float changeTime = 0.0f;

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
                changeTime = Time.time + Random.Range(timeMin, timeMax);
            }
            else
            {
                changeTime = Time.time + Random.Range(offMin, timeMin);
            }
        }
    }
}
