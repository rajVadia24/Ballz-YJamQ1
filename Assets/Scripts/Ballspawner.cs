using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Ballspawner : MonoBehaviour
{
    private Vector3 worldPosition;
    private Vector3 startPos, endPos;

    public GameObject ballPrefab;
    public Transform spawnPointer;
  
    int countTmep = 0;

    public static Ballspawner instance;

    public TextMeshProUGUI ballText;

    [HideInInspector]

    public bool isSpawnBall=false;

    Vector3 direction;

   

   public  int counterBall,tempdestroyBall;

   
    void Start()
    {
      
       instance = this;
        counterBall = 5;
        tempdestroyBall = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * - 10f;
            


        if (Input.GetMouseButtonDown(0))
        {
            mouseDonw(worldPosition);
        }
      else  if (Input.GetMouseButton(0))
        {
            mouseDrag(worldPosition);
        }
      else  if (Input.GetMouseButtonUp(0))
        {
            mouseUp();
        }

    }


    void mouseDonw(Vector3 worldPos)
    {
         startPos = worldPos;

        
    }

    private void mouseDrag(Vector3 worldPos)
    {
        endPos = worldPos;

      

    }


    private void mouseUp()
    {

        if (isSpawnBall == false)
        {
            isSpawnBall = true;
            direction = endPos - startPos;
            direction.Normalize();


            StartCoroutine(spawnBallPrefab());
        }
       

    }


    IEnumerator spawnBallPrefab()
    {

        

        for (int i = 1; i <= counterBall; i++)
        {
            GameObject BallObj = Instantiate(ballPrefab, spawnPointer.position, Quaternion.identity);
            BallObj.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.2f);
          //  tempdestroyBall = i;
           
        }
    }

 
}
