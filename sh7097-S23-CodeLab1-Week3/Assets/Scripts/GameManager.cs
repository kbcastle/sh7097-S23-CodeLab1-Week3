using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private int score = 0;
    
    const string DIR_DATA = "/Data/";
    const string FILE_FAIL_SCORE = "failureScore.txt";

    private string PATH_FAIL_SCORE;
    
    public const string PREF_FAIL_SCORE = "fScore";

    public int Score;
    {
        get { return score; }
        set;
        {
            score = value; 
            Debug.Log("new fail score");

            if (score > FailScore)
            {
                FailScore = score;
            }
        }
    }
    
    int failScore = 0;

    public int HighScore;
    {
        get
        {
            return failScore;
        }
        set
        {
            failScore = value;

            Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            File.WriteAllText(PATH_FAIL_SCORE, "" + failScore);
            
        }
    }
    
    public TextMeshPro textMeshPro;
    
    
    void Awake()
    {

        if (Instance == null) 
        {
            DontDestroyOnLoad(gameObject);
            Instance = this; 
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PATH_FAIL_SCORE = Application.dataPath + DIR_DATA + FILE_FAIL_SCORE;

        if (File.Exists(PATH_FAIL_SCORE))
        {
            FailScore = Int32.Parse(File.ReadAllText(PATH_FAIL_SCORE));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
