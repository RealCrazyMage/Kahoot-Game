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
            print(GameObject.Find("Question").GetComponent<Image>().color);
            print(new Color(56, 56, 56, 128));
            GameObject.Find("Question").GetComponent<Image>().color = new Color((float)150/255, (float)150/255, (float)150/255, (float)150/255);
            ScoreKeeper.DisplayFinalScore();
            timerText.text = "time: 0";
            return;
        }
        timeLeft -= Time.deltaTime;
        int timeInt = (int)timeLeft + 1;
        timerText.text = "time: " + timeInt.ToString();
        
    }

    void DisableButtons()
    {
        foreach(Button b in buttons)
        {
            b.interactable = false;
        }
    }

}
