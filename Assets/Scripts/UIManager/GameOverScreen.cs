using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField] private Button replay;
    [SerializeField] private Button PlayScreenBtn;
  

    // Start is called before the first frame update
    void Start()
    {
        replay.onClick.AddListener(MainScreenNavigate);
        PlayScreenBtn.onClick.AddListener(PlayScreenNavigate);
    

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MainScreenNavigate()
    {
        ScreenManager.instance.ShowNextScreen(ScreenType.MainScreen);

    }
    void PlayScreenNavigate()
    {
        ScreenManager.instance.ShowNextScreen(ScreenType.MainScreen);
    }

  


}
