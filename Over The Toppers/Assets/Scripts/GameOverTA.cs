using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverTA : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = GameManager.totalToppingsCollcted * 10 + GameManager.totalPizzaMade * 50 + GameManager.totalMessCleaned * 20 + GameManager.inspectionsPassed * 50;
        scoreText.text = ("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Stacking Test");
        }
    }
}
