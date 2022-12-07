 using UnityEngine;
 using System.Collections;
 
 public class RaycastCam : MonoBehaviour 
 {
     Ray ray;
     RaycastHit hit;

     float maxDistance = 100;
     private int layerMask = 1 << 6;
     
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit, maxDistance, layerMask))
         {
            if(Input.GetMouseButtonDown(0)) {
                print(hit.collider.name);
            }
         }
     }
 }