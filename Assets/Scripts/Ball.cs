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

    void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rgBody.velocity = rgBody.velocity.normalized * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomLine")
        {
        
            counterDestroy++;

            if(counterDestroy== Ballspawner.instance.ballPrefList.Count)
            {
                Ballspawner.instance.transform.position = new Vector2(gameObject.transform.position.x, -4.74f);
                Ballspawner.instance.ballText.transform.position= new Vector2(gameObject.transform.position.x, Ballspawner.instance.ballText.transform.position.y);

                Ballspawner.instance.ballT    ext.text = "X" + Ballspawner.instance.counterBall;
                Ballspawner.instance.tempdestroyBall = Ballspawner.instance.counterBall;
         
                Ballspawner.instance.ballPrefList.Clear();
                counterAddBall = 0;
                Ballspawner.instance.isSpawnBall = false;
            }

            Destroy(gameObject);

         
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "ballPower")
        {
            counterAddBall++;
            Destroy(collision.gameObject);
            Ballspawner.instance.counterBall += counterAddBall;
           
           
        }
    }


}
