using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public float Speed = 1f;
    public bool turnSwitch = false;  // 첫번째 타겟, 두번째 타겟 구분

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {

        if (((Vector3.Distance(transform.position, Target1.transform.position)) >= .001f))
        {
            if(turnSwitch == false)
                turnSwitch = false;  // 첫번째 타겟 이동
        }else
        {
            turnSwitch = true;   // 두번째 타겟으로 이동
        }

        if (!((Vector3.Distance(transform.position, Target2.transform.position)) < .001f))
        {
            if (turnSwitch == true)
                turnSwitch = true;  // 첫번째 타겟 이동
        }
        else
        {
            turnSwitch = false;   // 두번째 타겟으로 이동
        }

        if (turnSwitch)
        {   //false Target1쪽으로
            transform.position = Vector3.MoveTowards(transform.position, Target2.position, Speed * Time.deltaTime);
        }
        else
        {   //true  Target2쪽으로
            transform.position = Vector3.MoveTowards(transform.position, Target1.position, Speed * Time.deltaTime);
        }

    }
}
