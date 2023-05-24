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
    static int count;

   public static bool isPlay=false;

    private void Awake()
    {
        directionLine = GetComponent<DirectionLine>();
        blockSpawner = FindObjectOfType<BlockSpawner>();

    }

    private void OnEnable()
    {
        
        InputEnableDisable += OnmouseManage;

        GameStateManager.OnGameStateChange += ChangeState;
    }

    private void ChangeState(GameState gs)
    {
        switch (gs)
        {
            case GameState.GamePlay:
                Debug.Log("GamePLay");


                break;
            case GameState.PauseScreen:
                Debug.Log("Pause");
                break;
            case GameState.GameOver:
                Debug.Log("GameOver");
                break;
        }
    }

    void Start()
    {
        

        instance = this;
        //    counterBall = ObjectPool.instance.amountToPool;
        //    counterBall = 1;

      
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

       //     Debug.Log("DRAG" + endPos);

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

          //  Debug.Log("UP" + isSpawnBall);
        }
    }


    IEnumerator spawnBallPrefab()
    {

        Debug.Log("herer");
        count = counterBall;
        Debug.Log("ADD" + counterBall);
        for (int i = 1; i <= counterBall; i++)
        {
            tempdestroyBall = i;

            BallObj = ObjectPool.instance.pooObject();



            if (BallObj != null)
            {
                BallObj.transform.position = transform.position;
                BallObj.transform.rotation = transform.rotation;

                BallObj.SetActive(true);
                //BallObj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
                BallObj.GetComponent<Rigidbody2D>().AddForce(-direction);

                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                ballText.enabled = false;
            }


            if (count >= 0)
            {
                count = count - 1;
                ballText.text = "X" + count;
                Debug.Log(count);
            }
           
            //
           
            ballPrefList.Add(BallObj);




            yield return new WaitForSeconds(0.1f);

            countTmep = 1;


        }
        
    }

 
}
