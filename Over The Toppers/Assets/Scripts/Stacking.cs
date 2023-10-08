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

    private void Start()
    {
        GameManager.dirtyCount += 1;
        maker = GameObject.Find("Maker");
    }

    //when the topping collides with any topping/Pizza
    private void OnCollisionEnter(Collision collision)
    {
            //if it collides with the player
            if (collision.gameObject.tag == "Player" && gameObject.tag != "Trash")
            {
                {

                //set this object as a child of the pizza object
                gameObject.layer = collision.gameObject.layer;
                this.gameObject.transform.parent = collision.gameObject.transform;
                this.gameObject.tag = "Player";


                //set this objects tage to player
                MakerMovement.toppings.Add(gameObject);
                        player = true;
                        gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, gameObject.transform.position.y, collision.gameObject.transform.position.z);

                    //add to stack count
                    if (!stacked)
                    {
                        stacked = true;
                        GameManager.stackCount++;
                        GameManager.totalToppingsCollcted++;
                        GameManager.dirtyCount--;
                        Debug.Log(GameManager.stackCount);
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
            this.gameObject.tag = "Player";
            if(gameObject.transform.position.y < maker.transform.position.y)
            {
                gameObject.transform.position = new Vector3(maker.gameObject.transform.position.x, 4, maker.gameObject.transform.position.z);
            }
            gameObject.transform.position = new Vector3(maker.gameObject.transform.position.x, gameObject.transform.position.y, maker.gameObject.transform.position.z);
        }
    }

    private void OnDestroy()
    {
        if(gameObject.tag != "Player")
        {
            GameManager.dirtyCount--;
        }
    }
}
