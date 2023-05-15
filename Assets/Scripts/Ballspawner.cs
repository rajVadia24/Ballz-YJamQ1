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
 //   public Transform spawnPointer;
  
    int countTmep = 0;

    public static Ballspawner instance;

    public TextMeshProUGUI ballText;

    [HideInInspector]

    public bool isSpawnBall=false;

    Vector3 direction;

   
    public GameObject BallObj;

   public  int counterBall,tempdestroyBall,balldestroy;

   public List<GameObject> ballPrefList=new List<GameObject>();

   
    DirectionLine directionLine;

    BlockSpawner blockSpawner;
    private void Awake()
    {
        directionLine = GetComponent<DirectionLine>();
        blockSpawner = FindObjectOfType<BlockSpawner>();
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

        directionLine.lineRenderer.enabled = true;
         startPos = worldPos;
        directionLine.lineRenderer.enabled = true;
        directionLine.startPoints(transform.position);


    }

    private void mouseDrag(Vector3 worldPos)
    {
        endPos = worldPos;

        Vector3 directionLinePoint = endPos - startPos;
        directionLine.endPoints(transform.position-directionLinePoint);
    }


    private void mouseUp()
    {
        if (isSpawnBall == false)
        {
            isSpawnBall = true;
            direction = endPos - startPos;
            direction.Normalize();
            directionLine.lineRenderer.enabled = false;

            StartCoroutine(spawnBallPrefab());
        }
    }


    IEnumerator spawnBallPrefab()
    {

        for (int i = 1; i <= counterBall; i++)
        {
            BallObj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            BallObj.GetComponent<Rigidbody2D>().AddForce(-direction);

            ballPrefList.Add(BallObj);

            yield return new WaitForSeconds(0.1f);
            tempdestroyBall = i;


        }

        
    }

 
}
