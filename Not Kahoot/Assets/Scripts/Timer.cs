using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //in seconds, set to starting value initially
    [SerializeField] float timeLeft = 60;
    [SerializeField] Text timerText;
    [SerializeField] Button[] buttons;

    bool timeIsUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if (timeIsUp) { return; }
        if(timeLeft <= 0)
        {
            timeIsUp = true;
            DisableButtons();
            ScoreKeeper.DisplayFinalScore();
            timerText.text = "time: 0";
            return;
        }
        timeLeft -= Time.deltaTime;
        timerText.text = timeLeft.ToString();
        
    }

    void DisableButtons()
    {
        foreach(Button b in buttons)
        {
            b.interactable = false;
        }
    }

}
