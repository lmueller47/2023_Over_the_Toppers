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

    bool leadingCharForDelay = false;
    string leadingChar = "";
    string writer;

    public TMP_Text orderText;
    public TMP_Text inspectionText;
    public TMP_Text top;

    public GameObject panel;
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
        writer = inspectionText.text;
        inspectionText.text = "";
        panel.SetActive(false);
        top.text = ("" + 0);
    }

    // Update is called once per frame
    void Update()
    {
        top.text = "" + stackCount;
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
            if(pizzaMade < 4 || dirtyCount > 15)
            {
                //lose game load game over / end scene
                SceneManager.LoadScene("Game Over");

            }
            else
            {
                StartCoroutine(TypeWriterText());
                inspectionsPassed++;
                pizzaMade = 0;
            }
        }
    }
    
    IEnumerator TypeWriterText()
    {
        panel.SetActive(true);
        inspectionText.text = leadingCharForDelay ? leadingChar : "";

        foreach(char c in writer)
        {
            if(inspectionText.text.Length > 0)
            {
                inspectionText.text = inspectionText.text.Substring(0, inspectionText.text.Length - leadingChar.Length);
            }
            inspectionText.text += c;
            inspectionText.text += leadingChar;
            yield return new WaitForSeconds(.05f);
        }

        if(leadingChar != "")
        {
            inspectionText.text = inspectionText.text.Substring(0, inspectionText.text.Length - leadingChar.Length);
        }

        yield return new WaitForSeconds(2f);
        inspectionText.text = "";
        leadingChar = "";
        panel.SetActive(false);
    }
}
