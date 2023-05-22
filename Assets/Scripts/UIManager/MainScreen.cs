using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{

    [SerializeField] private Button HomeButton;
    public static bool ispawnObj = false;

   public 
    
    void Start()
    {
        
        HomeButton.onClick.AddListener(HomeBtn);

        //BlockSpawner.instance.GetComponent<BlockSpawner>().enabled = false;
        //Ballspawner.instance.InputEnableDisable = null;
        //BlockSpawner.instance.spawnBlocksAction = null;
        Ballspawner.isPlay = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

   public void HomeBtn()
   {
        ScreenManager.instance.ShowNextScreen(ScreenType.ScoreScreen);
        StartCoroutine(callPlayArea());
        //  Ballspawner.instance.isSpawnBall = false;
        AudioManager.instance.Play("button");
        Invoke("callPlayArea2", 0.5f);
       // Debug.Log("Hi....");
    }

    IEnumerator callPlayArea() {

        yield return new WaitForSeconds(0.5f);
        //BlockSpawner.instance.GetComponent<BlockSpawner>().enabled = true;
        //Ballspawner.instance.InputEnableDisable += Ballspawner.instance.OnmouseManage;
        //BlockSpawner.instance.spawnBlocksAction += BlockSpawner.instance.spawnBlock;
        ispawnObj = true;
        Ballspawner.isPlay = false;
        Debug.Log("isPlay...." + Ballspawner.isPlay);
    }


   public void callPlayArea2()
    {

       // yield return new WaitForSeconds(0.5f);
        //BlockSpawner.instance.GetComponent<BlockSpawner>().enabled = true;
        //Ballspawner.instance.InputEnableDisable += Ballspawner.instance.OnmouseManage;
        //BlockSpawner.instance.spawnBlocksAction += BlockSpawner.instance.spawnBlock;
        ispawnObj = true;
        Ballspawner.isPlay = false;
        Debug.Log("isPlay...." + Ballspawner.isPlay);
    }




}
