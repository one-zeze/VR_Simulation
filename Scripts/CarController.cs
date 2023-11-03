using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject[] resetPoint; //리셋 지점등록

    public float downForceValue;
    public float power = 100f; //모터 파워
    public float rot = 45f; //회전 각도
    public float maxBrakeTorque = 300f; //브레이크 
    public bool isbraking = false;
    public bool iscol = true; // 충돌있느냐
    Rigidbody rb;

    public WheelCollider[] wheels = new WheelCollider[4]; //휠콜라이더
    GameObject[] WheelMesh = new GameObject[4]; //실제바퀴

    void Start()
    {
        WheelMesh = GameObject.FindGameObjectsWithTag("WheelMesh"); //오브젝트 태그이름으로 찾기
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0); //차량 흔들림을 방지하기 위해, 무게중심을 y축으로 -1만큼 설정함

        for (int i = 0; i <= WheelMesh.Length; i++)
        {
            wheels[i].transform.position = WheelMesh[i].transform.position;
        }
    }

    void WheelPosAndAni()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            WheelMesh[i].transform.position = wheelPosition;
            WheelMesh[i].transform.rotation = wheelRotation;
        }
    }

    void AddDownForce()
    {
        rb.AddForce(-transform.up * downForceValue * rb.velocity.magnitude); //속도이 높을수록 차량이 받는 압력이 강해짐
    }

    void Braking()
    {
        if (isbraking)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = maxBrakeTorque;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = 0;
            }
        }
    }

    private void OnCollisionStay(Collision col) // 트리거와 충돌시
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            iscol = true;
            PosReset_Col();
        }

    }
    
    void PosReset_GetKeyDown()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three)) //3번키 입력시 차량위치 리셋
        {
            rb.velocity = Vector3.zero;
            /*transform.position = resetPoint[0].transform.position;
            transform.rotation = resetPoint[0].transform.rotation;*/
            //resetPoint[Random.Range(0,n)] -> n개의 리셋지점 중 랜덤으로 리셋하게됨
            transform.position = resetPoint[Random.Range(0, resetPoint.Length)].transform.position;
            transform.rotation = resetPoint[Random.Range(0, resetPoint.Length)].transform.rotation;
            return;
        }
    }

    void PosReset_Col()
    {
        if (iscol == true) 
        {
            rb.velocity = Vector3.zero;
            /*transform.position = resetPoint[0].transform.position;
            transform.rotation = resetPoint[0].transform.rotation;*/
            //resetPoint[Random.Range(0,n)] -> n개의 리셋지점 중 랜덤으로 리셋하게됨
            transform.position = resetPoint[Random.Range(0, resetPoint.Length)].transform.position;
            transform.rotation = resetPoint[Random.Range(0, resetPoint.Length)].transform.rotation;
            return;
        }
        iscol = false;
    }

    private void FixedUpdate()
    {
        WheelPosAndAni();
        AddDownForce();
        Braking();
        PosReset_GetKeyDown();

        for (int i = 0; i < wheels.Length; i++) //차량 전진,후진 좌우방향 조작
        {
            wheels[i].motorTorque = Input.GetAxis("Vertical") * power;
        }
        for (int i = 0; i < 2; i++)
        {
            wheels[i].steerAngle = Input.GetAxis("Horizontal") * rot;
        }

        if (Input.GetKey(KeyCode.Space)) //Space입력시 브레이크
        {
            isbraking = true;
        }
        else
        {
            isbraking = false;
        }
    }

}
