using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial2CarPlay : MonoBehaviour
{
    bool is_col = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SceneChange();
    }

    public void SceneChange()
    {
        if (is_col== true)
        {
            SceneManager.LoadScene("CarPlay");
            is_col = false;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        is_col = true;
    }
}
