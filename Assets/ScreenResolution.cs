using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    public GameObject playArea;
    void Start()
    {
        

        if(Screen.width==1080 && Screen.height == 1920)
        {
            Debug.Log("Screen Width : " + Screen.width + "Screen Height" + Screen.height);
        }
        else if (Screen.width == 720 && Screen.height == 1280)
        {
            Debug.Log("Screen Width : " + Screen.width + "Screen Height" + Screen.height);
        }
        else if (Screen.width == 1080 && Screen.height == 2160)
        {
            Debug.Log("Screen Width : " + Screen.width + "Screen Height" + Screen.height);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
