using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Canvas gameOver;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            Debug.Log("------ Game Over ------");

            SaveManager.instance.setHighScore(SaveManager.instance.highScr.ToString());
              ScreenManager.instance.ShowNextScreen(ScreenType.GameOverScreen);
          //  gameOver.GetComponent<Canvas>().enabled = true;
        }
    }
}
