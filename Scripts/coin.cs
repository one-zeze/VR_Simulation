using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        SoundManager2.instance.PlayBGM("Yutube0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        SoundManager2.instance.PlaySFX("coins");
        Destroy(gameObject);
        Debug.Log("This is voxel");
    }
}
