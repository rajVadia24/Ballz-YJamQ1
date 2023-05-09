using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed=10f;

    
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
}
