using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private GameObject ballspawner;

    [SerializeField]
    private GameObject scoreSpawnwer;

    private int  blockSize=7; 

    private float distanceBetweenBlocks=0.75f;

    private int rowSpan=1, scorePower=0;
   

    int counterPower=0;
    int maintainScore;

    private List<GameObject> blockSpawn = new List<GameObject>();
   
    GameObject ballSpawn, score;
   
    private void OnEnable()
    {
        for(int i = 1; i < 1; i++)
        {
            spawnBlock();
         }
    }

    public void spawnBlock()
    {

        foreach(var block in blockSpawn)
        {
            if(block != null)
            {
                block.transform.position += Vector3.down * distanceBetweenBlocks;
                counterPower = 0;
            }
           

        }

        for (int i = 1; i <= blockSize; i++)
        {
            if (UnityEngine.Random.Range(0, 100) <= 40)
            {
                GameObject block = Instantiate(blockPrefab, GetPosition(i), Quaternion.identity);

                int hitsBlock = UnityEngine.Random.Range(1, 3) * rowSpan;
                block.GetComponent<Block>().setHits(hitsBlock);

                blockSpawn.Add(block);
                maintainScore = i;
                Debug.Log(maintainScore);

            }
            else
            {
                Debug.Log("Elese");
                if (counterPower == 0 || scorePower==0)
                {
                   

                    if (UnityEngine.Random.Range(0, 100) <= 50 && rowSpan != 1)
                    {
                        counterPower = 1;
                        ballSpawn = Instantiate(ballspawner, GetPosition(i), Quaternion.identity);
                        Debug.Log("Pos=" + ballSpawn.transform.position);
                        blockSpawn.Add(ballSpawn);
                        Debug.Log("Balls Spawn");
                    }
                    if (UnityEngine.Random.Range(0, 100) <= 50 && rowSpan != 1 && i <= 7)
                    {

                        scorePower = 1;
                        Debug.Log("Call  " + (maintainScore + 1));
                        score = Instantiate(scoreSpawnwer, GetPosition(maintainScore+1), Quaternion.identity);
                        blockSpawn.Add(score);
                    }
                    maintainScore = i;
                    
                }

            }
        }
        rowSpan++; ;
    }

    private Vector2 GetPosition(int i)
    {
        Vector2 position = transform.position;
        position += Vector2.right * i * distanceBetweenBlocks;
        return position;
    }


     private void RandomColorBricks() {

        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
