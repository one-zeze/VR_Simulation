using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private Text CoinText;
    private bool Finish = false;
    private int CoinCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        CoinText = GameObject.Find("CoinCounter").GetComponent<Text>();
    }


    // Update is called once per frame
    private void Update()
    {
        CoinCountText();
        CoinCountReset();
    }

    void OnTriggerEnter(Collider col) // 충돌시
    {
         if (col.gameObject.CompareTag("Coin"))
         {
            CoinCount++;
         }
     }
 

    void CoinCountText()
    {
       CoinText.text = "획득한 코인의 갯수 " + CoinCount + ":5";
    }

    void CoinCountReset() // 위치 리셋시 코인 횟수 초기화
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            CoinCount = 0;
            Finish = false;
        }
    }

}