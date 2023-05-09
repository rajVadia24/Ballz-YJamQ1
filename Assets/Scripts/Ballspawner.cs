using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballspawner : MonoBehaviour
{
    private Vector3 worldPosition;
    private Vector3 startPos, endPos;

    public GameObject ballPrefab;
    public GameObject BallPos;
    Vector3 direction;
    void Start()
    {
        
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

        Debug.Log("StartPOs" + startPos);
    }

    private void mouseDrag(Vector3 worldPos)
    {
        endPos = worldPos;
        Debug.Log("EndPOs" + endPos);


        //direction = endPos - startPos;
        //direction.Normalize();
        //float rotatez = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        //BallPos.transform.localEulerAngles = new Vector3(0, 0, rotatez);
    }


    private void mouseUp()
    {
        Vector3 direction = endPos - startPos;
        direction.Normalize();

      var BallObj=Instantiate(ballPrefab,transform.position, Quaternion.identity);
        BallObj.GetComponent<Rigidbody2D>().AddForce(-direction);

    }



    //private void OnMouseDown()
    //{



    //    startPos = worldPosition;
    //    Debug.Log("OnMouseDownCall" + startPos);
    //}





    //private void OnMouseDrag()
    //{


    //    endPos = worldPosition;
    //    Debug.Log("OnMouseDrag" + endPos);

    //}

    //private void OnMouseUp()
    //{
    //    Vector3 direction = endPos - startPos;
    //    direction.Normalize();

    //    var BallObj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
    //    BallObj.GetComponent<Rigidbody2D>().AddForce(-direction);

    //    Debug.Log("OnMouseUp");

    //    //float rotatez = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

    //    //Vector2 playerPos;
    //    //playerPos = transform.position;
    //    //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    //    //float rotatez = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

    //    ////transform.rotation = Quaternion.Euler(0f, 0f, rotatez);
    //    ////  transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    //    //transform.localEulerAngles = new Vector3(0, 0, rotatez);



    //    //GameObject ballObj = Instantiate(ballPrefab, BallPos.transform.position, Quaternion.identity);

    //    //BallPos.transform.localEulerAngles = new Vector3(0, 0, rotatez);
    //    //ballObj.gameObject.GetComponent<Rigidbody2D>().AddForce(direction);
    //    //Debug.Log("OnMouseUp");

    //}
}
