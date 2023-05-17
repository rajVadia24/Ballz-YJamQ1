using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    static int coin;

    void Start()
    {
        coin = int.Parse(SaveManager.instance.scoreTxt.text);
        SaveManager.instance.scoreTxt.text = coin.ToString();
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
            SaveManager.instance.setCoin(coin.ToString());
        }
    }
}
