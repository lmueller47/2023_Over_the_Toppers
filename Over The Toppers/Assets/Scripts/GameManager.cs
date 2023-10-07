using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static bool pizzaDone;
    public static float order;

    public TMP_Text orderText;
    void Start()
    {
        order = 0;
        GenerateOrders.Order();
        stackCount = 0;
        pizzaMade = 0;
        dirtyCount = 0;
        totalPizzaMade = 0;
        totalMessCleaned = 0;
        totalToppingsCollcted = 0;
        inspectionsPassed = 0;
        pizzaDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(order != 0)
        {
            //display first element as ui for player
            orderText.text = ("Pizza with " + order + " toppings.");
        }
        else
        {
            orderText.text = "No Orders";
        }

        if(stackCount == order)
        {
            pizzaDone = true;
        }
        else
        {
            pizzaDone = false;
        }

        //timer for corperate inspection when timer is reset
        if(inspection)
        {
            //reset inspection
            inspection = false;

            //do inspection stuff
            if(pizzaMade < 4 || dirtyCount > 10)
            {
                //lose game load game over / end scene
                SceneManager.LoadScene("Game Over");

            }
            else
            {
                inspectionsPassed++;
                pizzaMade = 0;
            }
        }
    }
}
