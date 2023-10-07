using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerMovement : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    public float hAxis;
    public float vAxis;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(hAxis * speed, 0f, vAxis * speed);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //move up in z
            //transform.position = transform.position + new Vector3(0, 0, .01f * speed);
            hAxis = 0;
            vAxis = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //move down in z
            //transform.position = transform.position + new Vector3(0, 0, -.01f * speed);
            hAxis = -1;
            vAxis = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //down x
            //transform.position = transform.position + new Vector3(-.01f * speed, 0, 0);
            hAxis = 0;
            vAxis = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //up in x
            //transform.position = transform.position + new Vector3(.01f * speed, 0, 0);
            hAxis = 1;
            vAxis = 0;
        }
        else
        {
            hAxis = 0;
            vAxis = 0;
        }
    }
}
