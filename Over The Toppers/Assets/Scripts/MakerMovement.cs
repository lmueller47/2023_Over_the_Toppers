using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerMovement : MonoBehaviour
{
    public float hAxis;
    public float vAxis;

    public float speed = 20f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(hAxis * speed, 0f, vAxis * speed);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Oven" && Input.GetKeyDown(KeyCode.Space))
        {
            //destroy the topping

            //made the pizza
            GameManager.pizzaMade++;
            GameManager.totalPizzaMade++;
        }
        if (other.gameObject.tag == "Oven" && Input.GetKeyDown(KeyCode.Space))
        {
            //destroy the topping
        }
    }
}
