using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DayNightCycle : MonoBehaviour
{   
    //based on https://youtube.com/watch?v=33RL196x4LI
    
    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    public float startTime = 0.4f;
    private float timeRate;
    public Vector3 noon;
    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;
    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;
    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultiplier;
    // skip other lighting from tutorial
    // Start is called before the first frame update
    void Start()
    {
     timeRate = 1.0f/fullDayLength;
     time = startTime;
    }
    // Update is called once per frame
    void Update()
    {
        time += timeRate * Time.deltaTime;
        time %= 1.0f;
        // rotating the planets over time
        // sun is opposite to moon (difference of .5)
        sun.transform.eulerAngles = (time - 0.25f) * noon * 4.0f; 
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4.0f;
        // light intensity by evaluating animation curve
        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);
        // change colors
        sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time);
        // enable and disable sun
        if (sun.intensity == 0 && sun.gameObject.activeInHierarchy ) {
            sun.gameObject.SetActive(false);
        } else if (sun.intensity > 0 && !sun.gameObject.activeInHierarchy) {
            sun.gameObject.SetActive(true);
        }
        // enable and disable moon
        if (moon.intensity == 0 && moon.gameObject.activeInHierarchy ) {
            moon.gameObject.SetActive(false);
        } else if (moon.intensity > 0 && !moon.gameObject.activeInHierarchy) {
            moon.gameObject.SetActive(true);
        }
        // lighting and reflections intensity
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        // RenderSettings.reflectionIntensity = reflectionsIntensityMultiplier.Evaluate(time);

    }
}