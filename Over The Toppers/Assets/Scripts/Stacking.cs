using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    public bool player = false;
    public float hAxis;
    public float vAxis;
    public bool stacked = false;
    public GameObject maker;

    public static bool death = false;

    public float speed = 20f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.dirtyCount += 1;
        maker = GameObject.FindGameObjectWithTag("Player");
    }

    //when the topping collides with any topping/Pizza
    private void OnCollisionEnter(Collision collision)
    {
            //if it collides with the player
            if (collision.gameObject.tag == "Player")
            {
                {
                    //check to make sure collision is above the pizza
                    if (gameObject.transform.position.y >= 1)
                    {
                    //set this object as a child of the pizza object
                        this.gameObject.transform.parent = collision.gameObject.transform;


                        //set this objects tage to player
                        MakerMovement.toppings.Add(gameObject);
                        this.gameObject.tag = "Player";
                        player = true;
                        gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, gameObject.transform.position.y, collision.gameObject.transform.position.z);

                    //add to stack count
                    if (!stacked)
                        {
                        stacked = true;
                            GameManager.stackCount++;
                            GameManager.totalToppingsCollcted++;
                        Debug.Log(GameManager.stackCount);
                        }
                    }
                }
            }
            else
            {
                //change tag so it can collide with cleaner
                gameObject.layer = collision.gameObject.layer;
                this.gameObject.tag = "Trash";
        }
    }
    private void Update()
    {
        if(player)
        {
            gameObject.transform.position = new Vector3(maker.gameObject.transform.position.x, gameObject.transform.position.y, maker.gameObject.transform.position.z);
        }
    }
}
