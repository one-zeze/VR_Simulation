using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    private Text myState;
    private bool Finish = false;
    private bool PlayGoalSound = false;
    private bool CoinGet = false;
    private string MiddleLine_trrigered = "";
    private string Goal_trrigered = "��ǥ������ �����Ͽ����ϴ�.";
    private int MiddleLineCheck = 0;


    // Start is called before the first frame update
    void Start()
    {
        myState = GameObject.Find("State").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        SetCountText();
        SetStateReset();
        //SoundPlay_Goal();

    }

    void OnTriggerEnter(Collider col) // Ʈ���ſ� �浹��
    {
        if(col.gameObject.CompareTag("MiddleLine"))
        {
            MiddleLine_trrigered = "�߾Ӽ� ħ��!!!! ";
        }

        if (col.gameObject.CompareTag("Goal"))
        {
            Finish = true;
        }

        if (col.gameObject.CompareTag("Coin"))
        {
            CoinGet = true;
        }


    }

    void OnTriggerExit(Collider col)  // Ʈ���ſ� �浹�� ������ ��
    {
        if (col.gameObject.CompareTag("MiddleLine"))
        {
            MiddleLine_trrigered = "";
            MiddleLineCheck++;
        }

        if (col.gameObject.CompareTag("Goal"))
        {
            SoundManager2.instance.PlaySFX("CLAB");
            SoundManager2.instance.PlaySFX("PANG");
        }

        if (col.gameObject.CompareTag("Coin"))
        {
            CoinGet = false;
        }
    }

    void SetCountText()
    {
        if(Finish == false) 
        {
            myState.text = MiddleLine_trrigered + "\n" + "�߾Ӽ� ħ�� Ƚ�� :" + MiddleLineCheck;
        }

        if (Finish == true)
        {
            myState.text =  Goal_trrigered + "\n" + "�� �߾Ӽ� ħ�� Ƚ�� :" + MiddleLineCheck;
        }
    }

    void SetStateReset() // ��ġ ���½� �߾Ӽ� ħ�� Ƚ�� �ʱ�ȭ
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            MiddleLineCheck = 0;
            Finish = false;
            PlayGoalSound = false;
        }
    }

}