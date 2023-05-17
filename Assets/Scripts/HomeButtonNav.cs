using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButtonNav : MonoBehaviour
{

    [SerializeField] private Button HomeButton;


    // Start is called before the first frame update
    void Start()
    {
       HomeButton.onClick.AddListener(HomeBtn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HomeBtn()
    {
        ScreenNavigator.inst.ShowNextScreen(ScreenType.HomeScreen);
    }

   
}
