using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    /*
     * TODO: Sound effects when a button is clicked
     */

    // Start Menu Functions
    #region
    public void goto_start()
    {
        Debug.Log("Heading to subject section");
        SceneManager.LoadScene("LevelMenu");
    }

    public void goto_options()
    {
        Debug.Log("Heading to options");
        SceneManager.LoadScene("OptionsMenu");
    }

    public void quit()
    {
        Debug.Log("Quit");
        //For debugging purposes, should remove the bool assignment once game is built
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    #endregion

    //Level Functions
    #region
    public void goto_gameplay(string subject)
    {
        Debug.Log("Goto " + subject);
        SceneManager.LoadScene("Gameplay");
        FindObjectOfType<SceneData>().databaseName = subject + "Questions";
    }
    #endregion

    //Options Functions
    #region
    
    public void goto_main()
    {
        SceneManager.LoadScene("GameMenu");
    }
    
    public void volume()
    {

    }

    public void small()
    {

    }

    public void medium()
    {

    }

    public void large()
    {

    }
    #endregion
}
