using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public float Speed = 1f;
    public bool turnSwitch = false;  // ù��° Ÿ��, �ι�° Ÿ�� ����

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {

        if (((Vector3.Distance(transform.position, Target1.transform.position)) >= .001f))
        {
            if(turnSwitch == false)
                turnSwitch = false;  // ù��° Ÿ�� �̵�
        }else
        {
            turnSwitch = true;   // �ι�° Ÿ������ �̵�
        }

        if (!((Vector3.Distance(transform.position, Target2.transform.position)) < .001f))
        {
            if (turnSwitch == true)
                turnSwitch = true;  // ù��° Ÿ�� �̵�
        }
        else
        {
            turnSwitch = false;   // �ι�° Ÿ������ �̵�
        }

        if (turnSwitch)
        {   //false Target1������
            transform.position = Vector3.MoveTowards(transform.position, Target2.position, Speed * Time.deltaTime);
        }
        else
        {   //true  Target2������
            transform.position = Vector3.MoveTowards(transform.position, Target1.position, Speed * Time.deltaTime);
        }

    }
}
