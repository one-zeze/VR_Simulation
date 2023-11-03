using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Change : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera FirstPersonCamera;
    public Camera ThirdPersonCamera;

    public void Show3rdCamera() //3인칭으로 변경
    {
        FirstPersonCamera.enabled = false;
        ThirdPersonCamera.enabled = true;
    }
    public void Show1stCamera() // 1인칭으로 변경
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
