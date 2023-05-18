using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenresuluton : MonoBehaviour
{
    public GameObject backgroundImage;
    public Camera mainCam;

    void Start()
    {

        Vector2 deviceScreenResolution = new Vector2(Screen.width, Screen.height);

        float srcHeight = Screen.height;
        float srcWidth = Screen.width;

        float DEVICE_SCREEN_aSPECT = srcWidth / srcHeight;

        //Debug.Log("DEVICE_SCREEN_aSPECT==" + DEVICE_SCREEN_aSPECT);

        mainCam.aspect = DEVICE_SCREEN_aSPECT;

        float camHeight = 100.0f * mainCam.orthographicSize * 2f;

        float camWidth = camHeight * DEVICE_SCREEN_aSPECT * 1f;


        SpriteRenderer backGroundSR = backgroundImage.GetComponent<SpriteRenderer>();

        float bgImgH = backGroundSR.sprite.rect.height;
        float bgImgW = backGroundSR.sprite.rect.width;


        float bgScaleH = camHeight / bgImgH;
        float bgScaleW = camWidth / bgImgW;


        backgroundImage.transform.localScale = new Vector3(bgScaleW, bgScaleH, 1);
    }
}
