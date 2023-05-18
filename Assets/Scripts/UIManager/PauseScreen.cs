using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MainScreen
{

    [SerializeField] private Button continueBtn;
    [SerializeField] private Button PlayScreenBtn;
    [SerializeField] private Button restartBtn;


    MainScreen main = new MainScreen();
    void Start()
    {
        continueBtn.onClick.AddListener(MainScreenNavigate);
        PlayScreenBtn.onClick.AddListener(PlayScreenNavigate);
        restartBtn.onClick.AddListener(Restartgame);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MainScreenNavigate()
    {
        ScreenManager.instance.ShowNextScreen(ScreenType.ScoreScreen);
     
    }
    void PlayScreenNavigate()
    {

        main.GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene(1);
        main.HomeBtn();
    }

    void Restartgame()
    {
        ScreenManager.instance.ShowNextScreen(ScreenType.MainScreen);
    }


}
