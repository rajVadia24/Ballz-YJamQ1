using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed=1f;

    static int counterAddBall = 0;

    public static bool isDestroyAllObj = false;
    
    private Rigidbody2D rgBody;

    static int counterDestroy;


    DirectionLine directionLine;

    BlockSpawner blockSpawner;

   

    private void OnEnable()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
       // blockSpawner = GetComponent<BlockSpawner>();
    }

    void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
        directionLine = GetComponent<DirectionLine>();
       
    }

    private void FixedUpdate()
    {
        rgBody.velocity = rgBody.velocity.normalized * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomLine" && Ballspawner.countTmep==1)
        {
        
            counterDestroy++;

            Ballspawner.instance.ballText.text = "X" + counterDestroy;
            if (counterDestroy== Ballspawner.instance.ballPrefList.Count)
            {

             
                Ballspawner.countTmep = 0;
                Ballspawner.instance.ballPrefList.Clear();
               
            //    BlockSpawner.instance.spawnBlock();

                Ballspawner.instance.transform.position = new Vector2(gameObject.transform.position.x, -4.74f);
                Ballspawner.instance.ballText.transform.position= new Vector2(gameObject.transform.position.x, Ballspawner.instance.ballText.transform.position.y);

                Ballspawner.instance.ballText.text = "X" + Ballspawner.instance.counterBall;
              //  Ballspawner.instance.tempdestroyBall = Ballspawner.instance.counterBall;

               
              
                counterAddBall = 0;
                counterDestroy = 0;
                blockSpawner.spawnBlock();

                Ballspawner.instance.isSpawnBall = false;

                // directionLine.lineRenderer.enabled = false;

               
            }


            //  Destroy(gameObject);

            gameObject.SetActive(false);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "ballPower")
        {
            AudioManager.instance.Play("button");
            counterAddBall++;
            Ballspawner.instance.counterBall++; 
            Destroy(collision.gameObject);

        }
    }


}
