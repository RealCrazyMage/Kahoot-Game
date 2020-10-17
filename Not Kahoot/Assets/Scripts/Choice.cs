using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    bool isCorrect;
    string text = "";
    Text displayText;

    //called just before Start()
    private void Awake()
    {
        //initializes the Text component on the choice
        displayText = GetComponentInChildren<Text>();
        UpdateText();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //used to set the text that will be displayed
    public void SetText(string newText)
    {
        text = newText;
        UpdateText();
    }

    //used to set the correctness of the choice
    public void SetCorrect(bool correct)
    {
        isCorrect = correct;
        //test code so I can determine which one is correct even though the question is nonsense
        if (correct)
        {
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
        }
    }

    //updates the UI to display the value stored in text
    void UpdateText()
    {
        displayText.text = text;
    }

    public void ChoiceSelected()
    {
        ScoreKeeper.UpdateScore(isCorrect);
        FindObjectOfType<QuestionManager>().NewQuestion();
    }

}
