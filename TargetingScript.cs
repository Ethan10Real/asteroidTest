using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingScript : MonoBehaviour
{
    [SerializeField] private float speed = .3f;

    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material normalMaterial;

    private Ray ray;

    private Camera cam;
    private GameObject objHit = null;
    private float step;
    private bool asteroidSelected;

    void Start()
    {
        cam = Camera.main;
        step = speed * Time.deltaTime;
        asteroidSelected = false; //if an asteroid has been selected yet
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 headPosition = Camera.main.transform.position;
        Vector3 gazeDirection = Camera.main.transform.forward;

        int iLayermask = 1 << 8;
        iLayerMask = ~iLayerMask;
        */
        RaycastHit hit;

        ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.transform != objHit){

            ResetMaterial(objHit);
            objHit = hit.collider.gameObject;
            SelectedMaterial(objHit);
            
            asteroidSelected = true; 
        }

        if (asteroidSelected) { FollowAsteroid(); }

        
    }

    void FollowAsteroid(){
        Vector3 newDir = objHit.transform.position - this.transform.position;   

        Quaternion newRot = Quaternion.LookRotation(newDir);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRot, step);
    }

    void ResetMaterial(GameObject asteroid){ //sets asteroid material back to normal
        if (asteroid == null) {return;} 
        asteroid.GetComponent<MeshRenderer>().material = normalMaterial;
    }

    void SelectedMaterial(GameObject asteroid){ //sets asteroid material to Selected
    if (asteroid == null) {return;}
         asteroid.GetComponent<MeshRenderer>().material = selectedMaterial;
    }

}
