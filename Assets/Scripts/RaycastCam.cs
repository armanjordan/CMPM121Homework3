 using UnityEngine;
 using System.Collections;
 
 public class RaycastCam : MonoBehaviour 
 {
    // Variables to track raycast
    Ray ray;
    RaycastHit hit;

    float maxDistance = 6;
    private int layerMask = 1 << 6;

    // Global tracking of Objects clicked
    public static int numItems;

    // GameObject to display after all clues been clicked
    [SerializeField]
    private GameObject payoff;

    // Variable to track the particles attached to the interactables
    private ParticleSystem objParticles;

    // Initialize values
    void Start() 
    {
        numItems = 0;
        payoff.SetActive(false);
    }
    

    void Update()
    {
        // Grabs current ray
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                numItems += 1;
                print(numItems);
                objParticles = hit.transform.GetComponent<ParticleSystem>();
                objParticles.Stop(false);
                Destroy(hit.collider);
            }
        }

        if (numItems >= 5) {
            payoff.SetActive(true);
        }
    }
}