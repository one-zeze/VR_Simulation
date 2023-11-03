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

    void OnTriggerEnter(Collider col) // �浹��
    {
         if (col.gameObject.CompareTag("Coin"))
         {
            CoinCount++;
         }
     }
 

    void CoinCountText()
    {
       CoinText.text = "ȹ���� ������ ���� " + CoinCount + ":5";
    }

    void CoinCountReset() // ��ġ ���½� ���� Ƚ�� �ʱ�ȭ
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            CoinCount = 0;
            Finish = false;
        }
    }

}