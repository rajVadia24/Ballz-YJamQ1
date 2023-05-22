using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Ballspawner : MonoBehaviour
{
    private Vector3 worldPosition;
    private Vector3 startPos, endPos;

    public GameObject ballPrefab;
    //   public Transform spawnPointer;

    public static int countTmep = 0;

    public static Ballspawner instance;

    public TextMeshProUGUI ballText;

    [HideInInspector]

    public  bool isSpawnBall=false;

    Vector3 direction;
    Vector3 directionLinePoint;


    public GameObject BallObj;

   public  int counterBall,tempdestroyBall,balldestroy;

   public List<GameObject> ballPrefList=new List<GameObject>();

   
   private DirectionLine directionLine;

    BlockSpawner blockSpawner;


    public Action InputEnableDisable;


   public static bool isPlay=false;

    private void Awake()
    {
        directionLine = GetComponent<DirectionLine>();
        blockSpawner = FindObjectOfType<BlockSpawner>();

    }

    private void OnEnable()
    {
        
        InputEnableDisable += OnmouseManage;
    }


    void Start()
    {
        

        instance = this;
        counterBall = 1;
        ballText.text = "X" + counterBall;
        tempdestroyBall = 0;
        blockSpawner.spawnBlock();

    }

    // Update is called once per frame
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * - 10f;



       InputEnableDisable?.Invoke();

    }

    public void OnmouseManage()
    {

        if (isPlay==false)
        {
            Debug.Log("BallSpawner");
            if (Input.GetMouseButtonDown(0))
            {
                mouseDonw(worldPosition);
                // isSpawnBall = false;
            }
            else if (Input.GetMouseButton(0))
            {
                mouseDrag(worldPosition);
                //  isSpawnBall = false;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                mouseUp();

            }
        }
    }


    void mouseDonw(Vector3 worldPos)
    {
        if (isSpawnBall == false)
        {
            directionLine.lineRenderer.enabled = true;
            startPos = worldPos;
            directionLine.lineRenderer.enabled = true;
            directionLine.startPoints(transform.position);

            Debug.Log("DOWN" + isSpawnBall);

        }
    }

    private void mouseDrag(Vector3 worldPos)
    {
        if (isSpawnBall == false )
        {
            endPos = worldPos;
             directionLinePoint = endPos - startPos;
            directionLine.endPoints(transform.position - directionLinePoint);

            //if (endPos.x < 2.5f)
            //{
            //    directionLine.lineRenderer.enabled = false;
            //}
            //else
            //{
            //    directionLine.lineRenderer.enabled = true;
            //}

            Debug.Log("DRAG" + endPos);

        }
    }


    private void mouseUp()
    {
        if (isSpawnBall == false )
        {
            isSpawnBall = true;
            direction = endPos - startPos;
            direction.Normalize();
            directionLine.lineRenderer.enabled = false;

            StartCoroutine(spawnBallPrefab());

            Debug.Log("UP" + isSpawnBall);
        }
    }


    IEnumerator spawnBallPrefab()
    {

        for (int i = 1; i <= counterBall; i++)
        {
            tempdestroyBall = i;
            BallObj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            BallObj.GetComponent<Rigidbody2D>().AddForce(-direction);

            ballPrefList.Add(BallObj);

            yield return new WaitForSeconds(0.1f);
           
            countTmep = 1;

        }

        
    }

 
}
