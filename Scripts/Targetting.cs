using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    public GameObject Target;


    // Update is called once per frame
    void Update()
    {
        // 방향 구하기
        // 방향 벡터값 = 목표 벡터 - 시작 벡터
        Vector3 dir = Target.transform.position - transform.position; 
        dir.y = 0f;

        // 방향의 쿼터니언 값 구하기
        // 쿼터니언 값 = 쿼터니언 방향 값(방향 벡터)
        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        //방향 회전하기
        transform.rotation = rot;
    }
}
