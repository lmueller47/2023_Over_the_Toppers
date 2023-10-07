using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    //when the topping collides with any topping/Pizza
    private void OnCollisionEnter(Collision collision)
    {
        //set this object as a child of the pizza object
        this.gameObject.transform.parent = collision.gameObject.transform;
    }
}
