using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    /*
     * TODO: Sound effects when a button is clicked
     */
    AudioSource auditore;
    private void Start()
    {
        auditore = FindObjectOfType<SceneData>().GetComponent<AudioSource>();
    }

    // Start Menu Functions
    #region
    public void goto_start()
    {
        auditore.Play();
        Debug.Log("Heading to subject section");
        SceneManager.LoadScene("LevelMenu");
    }

    public void goto_options()
    {
        auditore.Play();
        Debug.Log("Heading to options");
        SceneManager.LoadScene("OptionsMenu");
    }

    public void quit()
    {
        auditore.Play();
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
        auditore.Play();
        Debug.Log("Goto " + subject);
        SceneManager.LoadScene("Gameplay");
        FindObjectOfType<SceneData>().databaseName = subject + "Questions";
    }
    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

    //Options Functions
    #region
    
    public void goto_main()
    {
        Debug.Log(auditore.clip);
        auditore.Play();
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
