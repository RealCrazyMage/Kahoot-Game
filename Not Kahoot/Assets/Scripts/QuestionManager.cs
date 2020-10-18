using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    //initialized via editor
    [SerializeField] Choice[] choices = new Choice[4];
    [SerializeField] Text prompt;
    [SerializeField] List<TextAsset> databases = new List<TextAsset>();

    /* In the event that we need to replenish the list of problems,
     *  we need to keep the name of the database we used originally to populate it
     *  so that we can populate it again
     */
    string databaseName;

    /* the database currently being pulled from, should be set via a menu
     * of some kind before the game is started by calling SetDatabase()
     * with a parameter for the subject's name. Current databases existig include:
     * MathQuestions */
    List<string> problems;

    //the total amount of problems in the database, needed for picking a random problem.
    //int problemsInDatabase;


    // Start is called before the first frame update
    void Start()
    {
        problems = new List<string>();
        SetDatabase(FindObjectOfType<SceneData>().databaseName, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //gives a new question, called at the start and whenever the previous question is answered.
    public void NewQuestion()
    {
        ResetChoices();
        string problem = problems[Random.Range(0, problems.Count)];
        string question = GetQuestion(problem);
        List<string> answers = GetAnswers(problem);
        prompt.text = question;
        for(int i = 0; i < choices.Length; i++)
        {
            int currentAnswer = Random.Range(0, answers.Count);
            bool correctAnswer = answers[currentAnswer][answers[currentAnswer].Length - 1] == '*'; //if the last char of the answer is *
            if (correctAnswer) //if the last char of the answer is *
            {
                choices[i].SetCorrect(true);
                //cut out the * that denotes that this is the correct answer
                answers[currentAnswer] = answers[currentAnswer].Substring(0, answers[currentAnswer].Length - 1);
            }
            choices[i].SetText(answers[currentAnswer]);
            answers.Remove(answers[currentAnswer]);
        }
        problems.Remove(problem);
        if(problems.Count == 0) //we have somehow ran out of problems in the time limit
        {
            //this effectively recreates the list of problems.
            Debug.LogWarning("We need to reset the problem list because you got " +
                "through all of the problems in one game. Please add more problems " +
                "to the database so this doesn't happen in the future");
            SetDatabase(databaseName, false);
        }
    }

    void ResetChoices()
    {
        foreach(Choice c in choices)
        {
            c.SetCorrect(false);
        }
    }

    string GetQuestion(string problem)
    {
        string returnString = "";
        foreach(char c in problem)
        {
            if(c == '\n')
            {
                return returnString;
            }
            returnString += c;
        }
        Debug.Log("Somehow there are no newlines in this problem, fix it");
        return "";
    }

    List<string> GetAnswers(string problem)
    {
        List<string> returnStrings = new List<string>();
        string currentAnswer = "";
        bool beyondQuestion = false;
        foreach (char c in problem)
        {
            if(c == '\n')
            {
                if (!beyondQuestion)//if this is the first newline
                {
                    beyondQuestion = true;
                    continue;
                }
                //end of answer
                returnStrings.Add(currentAnswer);
                currentAnswer = "";
            }
            else if(beyondQuestion)
            {
                currentAnswer += c;
            }
        }
        return returnStrings;
    }

    //splits the text files into 
    void SplitIntoProblems(string database)
    {
        int lines = 0; //there is no newline before the first line, so it starts at 1 to account for that.
        string currentProblem = "";
        bool currentProblemHasCorrectAnswer = false;
        foreach (char c in database)
        {
            currentProblem += c;
            if(c == '*')
            {
                currentProblemHasCorrectAnswer = true;
            }
            if (c == '\n')
            {
                lines++;
                if (lines == 5) //end of problem
                {
                    if (!currentProblemHasCorrectAnswer)
                    {
                        Debug.LogError("No correct answer is indicated in the following problem:\n" + currentProblem);
                    }
                    problems.Add(currentProblem);
                    currentProblem = "";
                    currentProblemHasCorrectAnswer = false;
                    lines = 0;
                }
            }

        }
        if (lines != 0) //if the amount of lines isn't divisible by 5, something is wack in the database.
        {
            Debug.LogError(
                "The database being used has an amount of lines that is " +
                "not a multiple of 5, please fix the database. Is there an " +
                "empty line at the end of the database? do all questions have " +
                "4 answers?");
        }
    }

    public void SetDatabase(string nameOfDatabase, bool firstSetup)
    {
        //only needed in the event that we need to repopulate the problems list
        databaseName = nameOfDatabase;

        bool foundDatabase = false;
        foreach(TextAsset ta in databases)
        {
            if(ta.name == nameOfDatabase)
            {
                SplitIntoProblems(ta.text);
                foundDatabase = true;
            }
        }
        if (!foundDatabase)
        {
            Debug.LogError("No databases in QuestionManager have the name " + databaseName);
        }
        if (firstSetup)
        {
            NewQuestion();
        }
    }
}
