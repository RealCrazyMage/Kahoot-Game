using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    /*
     * This is the object that contains button information
     * 
     */
    private bool is_correct;

     Button(bool is_correct)
    {
        this.is_correct = is_correct;
    }

    Button()
    {
        is_correct = false;
    }



}
