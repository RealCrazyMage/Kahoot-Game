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
    public void goto_math()
    {
        Debug.Log("Goto Math");
        SceneManager.LoadScene("SampleScene");
    }

    public void goto_grammar()
    {
        Debug.Log("Goto Grammar");
        SceneManager.LoadScene("GrammarScene");
    }

    public void goto_science()
    {
        Debug.Log("Goto Science");
        SceneManager.LoadScene("ScienceScene");
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
