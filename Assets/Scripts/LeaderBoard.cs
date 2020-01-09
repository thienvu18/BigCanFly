using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text;
using System.IO;
using System;

public class LeaderBoard : MonoBehaviour
{
    public string mainMenuScene;
    public HighScore[] score = new HighScore[10];

    // Start is called before the first frame update
    void Start()
    {
        string[] lines = File.ReadAllLines("Assets//Scripts//HighScore.txt");
        int count = 20;
        if (lines.Count() < 20)
        {
            count = lines.Count();
        }
        for (int i = 0; i < count; i += 2)
        {
            score[i / 2].number.text = (i / 2 + 1).ToString();
            score[i / 2].playerName.text = lines[i];
            score[i / 2].score.text = lines[i + 1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }
    
}
