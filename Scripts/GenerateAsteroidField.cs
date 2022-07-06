using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroidField : MonoBehaviour
{
    [SerializeField] private Transform AsteroidPrefab;
    [SerializeField] private Transform SpaceShipPrefab;

    private static int fieldRadius = 1;
    private static int asteroidCount = 10;

    public static Vector3 position;


    void Start()
    {
        position = transform.position;

        Transform ship = GameObject.Instantiate(SpaceShipPrefab, position, transform.rotation);
        ship.transform.parent = this.transform;

        for (int i = 0; i < asteroidCount; i++){
            Transform temp = GameObject.Instantiate(AsteroidPrefab, (Random.insideUnitSphere + position) * fieldRadius, Random.rotation);
            temp.transform.parent = this.transform;
            temp.localScale = temp.localScale * Random.Range(1f, 4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
