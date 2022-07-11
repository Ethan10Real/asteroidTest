using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateField : MonoBehaviour
{
    [SerializeField] private GameObject field;
    private const float rotateConst = .25f;

    void Update()
    {
        if (Input.GetKey("a")){
            field.transform.Rotate(0, rotateConst, 0);
        }
        if (Input.GetKey("d")){
            field.transform.Rotate(0, -rotateConst, 0);
        }
        if (Input.GetKey("w")){
            field.transform.Rotate(-rotateConst, 0, 0);
        }
        if (Input.GetKey("s")){
            field.transform.Rotate(rotateConst, 0, 0);
        }
    }
}
