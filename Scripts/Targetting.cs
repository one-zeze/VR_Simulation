using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    public GameObject Target;


    // Update is called once per frame
    void Update()
    {
        // ���� ���ϱ�
        // ���� ���Ͱ� = ��ǥ ���� - ���� ����
        Vector3 dir = Target.transform.position - transform.position; 
        dir.y = 0f;

        // ������ ���ʹϾ� �� ���ϱ�
        // ���ʹϾ� �� = ���ʹϾ� ���� ��(���� ����)
        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        //���� ȸ���ϱ�
        transform.rotation = rot;
    }
}
