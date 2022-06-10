using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAstroidField : MonoBehaviour
{
    public Transform AstroidPrefab;
    public int fieldRadius = 20;
    public int astroidCount = 250;
    public Vector3 size;
    private Rigidbody rg;

    void Start()
    {
        
        for(int i = 0; i < astroidCount; i++)
        {
            Transform temp = Instantiate(AstroidPrefab, Random.insideUnitSphere * fieldRadius, Random.rotation); //generate astroid field
            temp.localScale = temp.localScale * Random.Range(0.5f, 5); //create the astroid size
            
            rg = temp.GetComponent<Rigidbody>(); //select the mass for the astroid
            rg.mass = temp.localScale[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

