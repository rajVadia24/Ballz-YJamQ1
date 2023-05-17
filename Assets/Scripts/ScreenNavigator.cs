using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenNavigator : MonoBehaviour
{
    public BaseClass[] screens;
    public BaseClass currentScreen;
    public static ScreenNavigator inst;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        currentScreen.canvas.enabled = true;
    }

    public void ShowNextScreen(ScreenType screenType)
    {
        currentScreen.canvas.enabled = false;

        foreach (BaseClass baseScreen in screens)
        {
            if (baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = true;
                break;
            }

            currentScreen = baseScreen;
        }
    }
}
