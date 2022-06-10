using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

	float G = 0.0006674f;

	public static List<Attractor> Attractors;

	public Rigidbody rb;
    private float radiusField = 15;

    private Vector3 center = new Vector3(0, 0, 0);

	void FixedUpdate ()
	{
		foreach (Attractor attractor in Attractors)
		{
			if (attractor != this)
				Attract(attractor);
		}
	}

	void OnEnable ()
	{
		if (Attractors == null)
			Attractors = new List<Attractor>();

		Attractors.Add(this);
	}

	void OnDisable ()
	{
		Attractors.Remove(this);
	}

	void Attract (Attractor objToAttract)
	{
        Rigidbody rbToAttract = objToAttract.rb;
        
        Vector3 direction = center - rb.position;

        float distance = direction.magnitude;

        if (distance == 0f)
            return;
        
        if (distance > radiusField)
        {
            G = 0.006674f;
        }
        else 
        {
            G = 0.000006674f;
        }
        float forceMagnitude = G * (rb.mass * 1000) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rb.AddForce(force);




		// Rigidbody rbToAttract = objToAttract.rb;


		// Vector3 direction = rb.position - rbToAttract.position;
		// float distance = direction.magnitude;

		// if (distance == 0f)
		// 	return;

        

		// float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
		// Vector3 force = direction.normalized * forceMagnitude;

		// rbToAttract.AddForce(force);
	}
}
