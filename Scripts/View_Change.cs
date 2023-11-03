using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Change : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera FirstPersonCamera;
    public Camera ThirdPersonCamera;

    public void Show3rdCamera() //3��Ī���� ����
    {
        FirstPersonCamera.enabled = false;
        ThirdPersonCamera.enabled = true;
    }
    public void Show1stCamera() // 1��Ī���� ����
    {
        ThirdPersonCamera.enabled = false;
        FirstPersonCamera.enabled = true;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Show1stCamera();
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Show3rdCamera();
        }
    }
}
