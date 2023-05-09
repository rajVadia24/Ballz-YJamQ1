using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballspawner : MonoBehaviour
{
    private Vector3 worldPosition;
    private Vector3 startPos, endPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void OnMouseDown()
    {
        startPos = worldPosition;
    }

    private void OnMouseDrag()
    {
        endPos = worldPosition;
    }

    private void OnMouseUp()
    {
        Vector3 direction = endPos - startPos;
    }
}
