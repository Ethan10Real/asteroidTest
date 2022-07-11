using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Transform target;
    void Update()
    {
        transform.LookAt(target);

        if (Input.GetKey("a")){
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey("d")){
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey("w")){
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        if (Input.GetKey("s")){
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
}
