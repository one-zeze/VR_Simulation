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
    private string Goal_trrigered = "목표지점에 도착하였습니다.";
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

    void OnTriggerEnter(Collider col) // 트리거와 충돌시
    {
        if(col.gameObject.CompareTag("MiddleLine"))
        {
            MiddleLine_trrigered = "중앙선 침범!!!! ";
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

    void OnTriggerExit(Collider col)  // 트리거와 충돌이 끝났을 때
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
            myState.text = MiddleLine_trrigered + "\n" + "중앙선 침범 횟수 :" + MiddleLineCheck;
        }

        if (Finish == true)
        {
            myState.text =  Goal_trrigered + "\n" + "총 중앙선 침범 횟수 :" + MiddleLineCheck;
        }
    }

    void SetStateReset() // 위치 리셋시 중앙선 침범 횟수 초기화
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            MiddleLineCheck = 0;
            Finish = false;
            PlayGoalSound = false;
        }
    }

}