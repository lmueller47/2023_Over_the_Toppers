using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateOrders : MonoBehaviour
{
    public static void Order()
    {
        //generate topping amount
        float toppings = Mathf.Round(Random.Range(1, 3));

        //set that to GM
        GameManager.order = toppings;
    }
}
