using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;

    public float offsetX;
    public float offsetY;
    public float offsetZ;


    void Update()
    {
        Vector3 FixedPos =
            new Vector3(
            target.transform.position.x + offsetX,
            target.transform.position.y + offsetY,
            target.transform.position.z + offsetZ);
        transform.position = FixedPos;
    }
}
