using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public string databaseName;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
