using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    static int score;
    static int correctReward = 2;
    static int incorrectPenalty = 1;
    static int questionsCorrect = 0;
    static int questionsIncorrect = 0;

    static Text scoreText;
    static GameObject endScreen;
    static Text[] endScreenStats = new Text[4];
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        endScreen = GameObject.Find("EndScreen");
        endScreenStats = endScreen.GetComponentsInChildren<Text>();
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
        endScreenStats[0].text = "Score:\n" + score;
        //TODO: implement high score dispay on end results
        endScreenStats[1].text = "Answers:\n" + (questionsIncorrect + questionsCorrect);
        endScreenStats[2].text = "Accuracy:\n" + Mathf.Round(100.0f * questionsCorrect / (questionsIncorrect + questionsCorrect)) + "%";
    }
    //TODO: display final score
    public static void DisplayFinalScore()
    {
        CanvasGroup canvasGroup = endScreen.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        score = 0;
        questionsCorrect = 0;
        questionsIncorrect = 0;
    }
}
