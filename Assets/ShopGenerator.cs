using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGenerator : MonoBehaviour
{
    public BallShop_SO ballSoap;

    public GameObject buttonPrefab, parrentObj;

    GameObject buttonObj;
    void Start()
    {
        ballSoap = GetComponent<BallShop_SO>();
    }


    public void callData()
    {
        for(int i=0;i<= ballSoap.shopsData.Count; i++)
        {
            buttonObj = Instantiate(buttonPrefab);
            buttonObj.transform.parent = parrentObj.transform;
            buttonObj.GetComponent<SpriteRenderer>().sprite = ballSoap.shopsData[i].buttonBallIcon;

            Debug.Log("CalllScriptable Obj");
        }
    }
}
