using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerMovement : MonoBehaviour
{
    public float speed = 6f;
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //move up in z
            //transform.position = transform.position + new Vector3(0, 0, .01f * speed);
            hAxis = 0;
            vAxis = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //move down in z
            //transform.position = transform.position + new Vector3(0, 0, -.01f * speed);
            hAxis = 0;
            vAxis = -1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //down x
            //transform.position = transform.position + new Vector3(-.01f * speed, 0, 0);
            hAxis = -1;
            vAxis = 0;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
        }
    }
}
