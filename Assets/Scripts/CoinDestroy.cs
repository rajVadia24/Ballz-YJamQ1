using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    static int coin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Destroy(gameObject);

            coin += 1;
          //  CoinManage.instance.setScore(CoinManage.instance.coinVal.ToString());
            SaveManager.instance.setCoin(coin.ToString());
        }
    }
}
