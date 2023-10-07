using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaOven : MonoBehaviour
{
    public static bool makePizza = false;
    public GameObject Oven;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            makePizza = true;
            Destroy(Oven);
            makePizza = false;
        }
    }
}
