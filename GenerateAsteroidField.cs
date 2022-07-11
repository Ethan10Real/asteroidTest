using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroidField : MonoBehaviour
{
    [SerializeField] private Transform AsteroidPrefab;
    [SerializeField] private Transform SpaceShipPrefab;

    [SerializeField] private int fieldRadius = 1;
    [SerializeField] private int asteroidCount = 10;
    
    [SerializeField] private float fieldMultiplier = .02f;

    public static Vector3 position;


    void Start(){
        StartCoroutine(WaitforClick());

        fieldMultiplier *= fieldRadius;

    IEnumerator WaitforClick(){
     
           while(true)
             {
                 if(Input.GetMouseButtonDown(0))
                 {                
                    GenerateField();
                    
                    yield break;                                    
                 }
                 yield return null;
             }
     }

    void GenerateField(){
        position = transform.position;

        Transform ship = GameObject.Instantiate(SpaceShipPrefab, position, transform.rotation);
        ship.transform.localScale *= fieldMultiplier;
        ship.transform.parent = this.transform;

        for (int i = 0; i < asteroidCount; i++){
            Transform asteroid = GameObject.Instantiate(AsteroidPrefab, (Random.insideUnitSphere + position) * fieldRadius, Random.rotation); //spawn asteroid
            asteroid.transform.localScale *= fieldMultiplier;
            asteroid.transform.parent = this.transform;
            asteroid.localScale = asteroid.localScale * Random.Range(5f, 10f);
        }

        // StartCoroutine(WaitThreeSec());
    }

    
    // IEnumerator WaitThreeSec(){  
    //          while(true)
    //          {
    //             PushAsteroid();
    //          }
    //          yield return new WaitForSeconds(3);

    // }

    // void PushAsteroid(){

    // }
   
    }
}



