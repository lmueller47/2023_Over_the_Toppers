using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    public bool player = false;
    public float hAxis;
    public float vAxis;
    public bool stacked = false;

    public float speed = 20f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.dirtyCount += 1;
    }

    //when the topping collides with any topping/Pizza
    private void OnCollisionEnter(Collision collision)
    {
            //if it collides with the player
            if (collision.gameObject.tag == "Player")
            {
                {
                    //check to make sure collision is above the pizza
                    if (gameObject.transform.position.y >= 2)
                    {
                        //set this object as a child of the pizza object
                        this.gameObject.transform.parent = collision.gameObject.transform;

                        //set this objects tage to player
                        this.gameObject.tag = "Player";
                    player = true;

                        //add to stack count
                        if(!stacked)
                        {
                            GameManager.stackCount++;
                            GameManager.totalToppingsCollcted++;
                        }
                    }
                }
            }
            else
            {
                //change tag so it can collide with cleaner
                //gameObject.layer = collision.gameObject.layer;
                this.gameObject.tag = "Trash";
        }
    }
    private void Update()
    {
        if(player)
        {
            //set x and y of this object to scale with x and y of player object 
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

    private void FixedUpdate()
    {
        if(player)
        {
            rb.velocity = new Vector3(hAxis * speed, 0f, vAxis * speed);
        }
    }
}
