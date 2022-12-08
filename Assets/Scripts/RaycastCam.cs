 using UnityEngine;
 using System.Collections;
 
 public class RaycastCam : MonoBehaviour 
 {
     Ray ray;
     RaycastHit hit;
     public static int numItems;

     float maxDistance = 100;
     private int layerMask = 1 << 6;

     [SerializeField]
     private GameObject particles;

     void Start() 
     {
        numItems = 0;
        particles.SetActive(false);
     }
     
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit, maxDistance, layerMask))
         {
            if(Input.GetMouseButtonDown(0)) 
            {
                numItems += 1;
                print(numItems);
                Destroy(hit.collider);
            }
         }

         if (numItems >=5 ) {
            particles.SetActive(true);
         }
     }
 }