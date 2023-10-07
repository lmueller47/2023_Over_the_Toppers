using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float stackCount;
    public static bool inspection = false;
    public static int pizzaMade;
    public static int dirtyCount;
    public static int totalPizzaMade;
    public static int totalMessCleaned;
    public static int totalToppingsCollcted;
    public static int inspectionsPassed;
    public static List<float> orders = new List<float>();

    public TMP_Text orderText;
    void Start()
    {
        stackCount = 0;
        pizzaMade = 0;
        dirtyCount = 0;
        totalPizzaMade = 0;
        totalMessCleaned = 0;
        totalToppingsCollcted = 0;
        inspectionsPassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(orders.Count > 0)
        {
            //display first element as ui for player
            orderText.text = ("Pizza with " + orders[0] + " toppings.");
        }
        else
        {
            orderText.text = "No Orders";
        }
        //change pizza player speed value based on topping stackCount
        //timer for corperate inspection when timer is reset
        if(inspection)
        {
            //reset inspection
            inspection = false;

            //do inspection stuff
            if(pizzaMade < 10 || dirtyCount > 10)
            {
                //lose game load game over / end scene
            }
            else
            {
                inspectionsPassed++;
                pizzaMade = 0;
            }
        }
    }
}
