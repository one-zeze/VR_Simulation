using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Threading;

public class Timer : MonoBehaviour
{
    private Text playTime;
    private float timeCount = 0;
    private bool Finish = false;

    // Start is called before the first frame update
    void Start()
    {
        playTime = GameObject.Find("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Finish == false)
        {
            timeCount += Time.deltaTime;
        }
        SetCountText();
        SetTimeReset();
    }

    void OnTriggerEnter(Collider col) // Ʈ���ſ� �浹��
    {
        if (col.gameObject.CompareTag("Goal"))
            Finish = true;

    }

    void SetCountText()
    {
        if (Finish == false)
        {
            playTime.text = "Playtime: " + string.Format("{0:N2}", timeCount);
        }

        if (Finish == true)
        {
            playTime.text = "Playtime: " + string.Format("{0:N2}", timeCount);
        }
    }

    void SetTimeReset() // ��ġ ���½� �ð� �ʱ�ȭ
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            timeCount = 0;
            Finish = false;
        }
    }

}