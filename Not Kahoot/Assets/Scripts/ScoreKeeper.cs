using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    static int score;
    static int correctReward = 2;
    static int incorrectPenalty = 1;
    static int questionsCorrect = 0;
    static int questionsIncorrect = 0;

    static Text scoreText;
    static GameObject EndScreen;
    static Text[] EndScreenStats = new Text[4];
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        EndScreen = GameObject.Find("EndScreen");
        EndScreenStats = EndScreen.GetComponentsInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void UpdateScore(bool correct)
    {
        if (correct)
        {
            score += correctReward;
            questionsCorrect++;
        }
        else
        {
            score -= incorrectPenalty;
            questionsIncorrect++;
            //cap penalty for getting it wrong at 0
            if (score < 0)
            {
                score = 0;
            }
        }
        //UI updates:
        scoreText.text = "Score: " + score;
        EndScreenStats[0].text = "Score:\n" + score;
        //TODO: implement high score dispay on end results
        EndScreenStats[2].text = "Answers:\n" + (questionsIncorrect + questionsCorrect);
        EndScreenStats[3].text = "Accuracy:\n" + 100.0f * questionsCorrect / (questionsIncorrect + questionsCorrect) + "%";
    }
    //TODO: display final score
    public static void DisplayFinalScore()
    {
        EndScreen.GetComponent<CanvasGroup>().alpha = 1;
    }
}
