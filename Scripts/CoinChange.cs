using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinChange : MonoBehaviour
{
    bool iscol = false; // �� �浹��?
    public float rotSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
        SetStateReset();
    }

    void OnTriggerEnter(Collider col) // Ʈ���ſ� �浹��
    {
        if (col.gameObject.CompareTag("Car"))
        {
            iscol = true;
            SoundManager2.instance.PlaySFX("Coins0");
            transform.position += new Vector3(0, -200, 0);
        }

    }

    void SetStateReset() // ��ġ ���½� �߾Ӽ� ħ�� Ƚ�� �ʱ�ȭ
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (iscol == true) {
                transform.position += new Vector3(0, +200, 0);
                iscol = false;
            }
        }
    }
}

