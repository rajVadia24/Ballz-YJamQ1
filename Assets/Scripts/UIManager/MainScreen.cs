using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{

    [SerializeField] private Button HomeButton;


    // Start is called before the first frame update
    void Start()
    {
        HomeButton.onClick.AddListener(HomeBtn);
        Ballspawner.instance.InputEnableDisable = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

   public void HomeBtn()
   {
        ScreenManager.instance.ShowNextScreen(ScreenType.ScoreScreen);
        Ballspawner.instance.InputEnableDisable += Ballspawner.instance.OnmouseManage;
      //  Ballspawner.instance.isSpawnBall = false;
        Debug.Log("Hi....");
       

    }


}
