using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject[] resetPoint; //���� �������

    public float downForceValue;
    public float power = 100f; //���� �Ŀ�
    public float rot = 45f; //ȸ�� ����
    public float maxBrakeTorque = 300f; //�극��ũ 
    public bool isbraking = false;
    public bool iscol = true; // �浹�ִ���
    Rigidbody rb;

    public WheelCollider[] wheels = new WheelCollider[4]; //���ݶ��̴�
    GameObject[] WheelMesh = new GameObject[4]; //��������

    void Start()
    {
        WheelMesh = GameObject.FindGameObjectsWithTag("WheelMesh"); //������Ʈ �±��̸����� ã��
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0); //���� ��鸲�� �����ϱ� ����, �����߽��� y������ -1��ŭ ������

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
        rb.AddForce(-transform.up * downForceValue * rb.velocity.magnitude); //�ӵ��� �������� ������ �޴� �з��� ������
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

    private void OnCollisionStay(Collision col) // Ʈ���ſ� �浹��
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            iscol = true;
            PosReset_Col();
        }

    }
    
    void PosReset_GetKeyDown()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three)) //3��Ű �Է½� ������ġ ����
        {
            rb.velocity = Vector3.zero;
            /*transform.position = resetPoint[0].transform.position;
            transform.rotation = resetPoint[0].transform.rotation;*/
            //resetPoint[Random.Range(0,n)] -> n���� �������� �� �������� �����ϰԵ�
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
            //resetPoint[Random.Range(0,n)] -> n���� �������� �� �������� �����ϰԵ�
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

        for (int i = 0; i < wheels.Length; i++) //���� ����,���� �¿���� ����
        {
            wheels[i].motorTorque = Input.GetAxis("Vertical") * power;
        }
        for (int i = 0; i < 2; i++)
        {
            wheels[i].steerAngle = Input.GetAxis("Horizontal") * rot;
        }

        if (Input.GetKey(KeyCode.Space)) //Space�Է½� �극��ũ
        {
            isbraking = true;
        }
        else
        {
            isbraking = false;
        }
    }

}
