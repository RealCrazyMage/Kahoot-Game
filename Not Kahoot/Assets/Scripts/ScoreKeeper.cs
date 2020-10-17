using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    static int score;
    static int correctReward = 2;
    static int incorrectPenalty = 1;

    static Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print(score);
        }
    }

    public static void UpdateScore(bool correct)
    {
        if (correct)
        {
            score += correctReward;
        }
        else
        {
            score -= incorrectPenalty;
            //cap penalty for getting it wrong at 0
            if (score < 0)
            {
                score = 0;
            }
        }
        //changes it in the UI;
        scoreText.text = "Score: " + score;
    }
}
