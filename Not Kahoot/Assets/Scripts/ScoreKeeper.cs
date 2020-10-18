using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    static int highScore = 0;
    static int score = 0;
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
        UpdateEndScreen();
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
        UpdateEndScreen();
    }

    private static void UpdateEndScreen()
    {
        scoreText.text = "Score: " + score;
        endScreenStats[0].text = "Score:\n" + score;
        endScreenStats[1].text = "High Score:\n" + highScore;
        endScreenStats[2].text = "Answers:\n" + (questionsIncorrect + questionsCorrect);
        if(questionsIncorrect == 0 && questionsCorrect == 0) //you did literally nothing what is wrong with you
        {
            endScreenStats[3].text = "Accuracy:\n0%"; 
        }
        else
        {
            endScreenStats[3].text = "Accuracy:\n" + Mathf.Round(100.0f * questionsCorrect / (questionsIncorrect + questionsCorrect)) + "%";

        }
    }

    //TODO: display final score
    public static void DisplayFinalScore()
    {
        if(score > highScore)
        {
            highScore = score;
        }
        UpdateEndScreen();

        CanvasGroup canvasGroup = endScreen.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        score = 0;
        questionsCorrect = 0;
        questionsIncorrect = 0;
    }
}
