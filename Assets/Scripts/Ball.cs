using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed=10f;

    int counterAddBall = 0;

    public static bool isDestroyAllObj = false;
    
    private Rigidbody2D rgBody;

   

    void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

     // transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rgBody.velocity = rgBody.velocity.normalized * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomLine")
        {
            Ballspawner.instance.tempdestroyBall = Ballspawner.instance.counterBall;

            Ballspawner.instance.tempdestroyBall++;

            Debug.Log(Ballspawner.instance.tempdestroyBall);

            if (Ballspawner.instance.tempdestroyBall == Ballspawner.instance.counterBall)
            {
               
                Ballspawner.instance.ballText.text = "X" + Ballspawner.instance.counterBall;
                Ballspawner.instance.tempdestroyBall = Ballspawner.instance.counterBall;
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
          
            Ballspawner.instance.counterBall += counterAddBall;
            Ballspawner.instance.tempdestroyBall++;
            Destroy(collision.gameObject);

            
           
        }
    }


}
