using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateOrders : MonoBehaviour
{
    public bool ordering = false;
    private void Update()
    {
        if (!ordering)
        {
            ordering = true;
            StartCoroutine(Order());
        }
    }

    public IEnumerator Order()
    {
        //generate topping amount
        float toppings = Mathf.Round(Random.Range(3, 7));
        //create order list for player to see ui
        //selected first order must be done first
        GameManager.orders.Add(toppings);
        yield return new WaitForSeconds(Random.Range(5, 12.5f));
        ordering = false;
    }
}
