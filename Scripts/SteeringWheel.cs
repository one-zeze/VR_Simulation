using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    public float steeringMax = 90f;
    public float steeringMin = -90f;
    // Update is called once per frame
    void Steering()
    {
        Vector3 steerAngle = Vector3.zero;
        transform.Rotate(Vector3.back * Input.GetAxis("Horizontal") * 2);
    }

    void Update()
    {
        
        Steering();
    }
}
