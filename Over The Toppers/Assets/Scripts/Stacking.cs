using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
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

                        //add to stack count
                        GameManager.stackCount += 1;
                    }
                }
            }
            else
            {
                //change tag so it can collide with cleaner
                this.gameObject.tag = "Trash";
            }
        }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cleaner")
        {
            Destroy(gameObject);
        }
    }
}
