
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public Transform pivotObject;
    public float rotationAngle = 90f;
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, Vector3.up, rotationAngle*Time.deltaTime);
        transform.LookAt(target);
    }
}
