using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Text;
using System.IO;
using System;

public class PauseManu : MonoBehaviour
{
    private float update;

    public GameObject optionsScreen, pauseScreen; 

    public GameObject loadingScreen, loadingIcon;
    public GameObject endGameScreen;
    public Text loadingText;
    public TextMeshProUGUI playerNameText;
    public GameObject gameInfo;
    public LevelManager playerGame;

    public string mainMenuScene;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        playerGame = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
        
    }

    public void PauseUnpause()
    {
        if (!isPaused)
        {
            pauseScreen.SetActive(true);
            gameInfo.SetActive(false);
            isPaused = true;

            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            gameInfo.SetActive(true);
            isPaused = false;

            Time.timeScale = 1f;
        }
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitToMain()
    {
        //SceneManager.LoadScene(mainMenuScene);
        //Time.timeScale = 1f;
        StartCoroutine(LoadMain());
    }

    public IEnumerator LoadMain()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainMenuScene);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                loadingText.text = "Press any key to continue";
                loadingIcon.SetActive(false);

                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;

                    Time.timeScale = 1f;
                }
            }

            yield return null;
        }
    }

    public void OpenScreen()
    {
        endGameScreen.SetActive(true);
        Time.timeScale = 0f;
        gameInfo.SetActive(false);
    }

    public void ExitEndGame()
    {
        Time.timeScale = 1f;
        endGameScreen.SetActive(false);
        Debug.Log(playerNameText.text);
        Debug.Log(playerGame.coins);
        List<KeyValuePair<string, int>> listvalue = loadFromFile("Assets//Scripts//HighScore.txt");
        listvalue.Add(new KeyValuePair<string, int>(playerNameText.text, playerGame.coins));
        sort(listvalue);
        writeToFile("Assets//Scripts//HighScore.txt", listvalue);
        SceneManager.LoadScene(mainMenuScene);
    }

    private List<KeyValuePair<string, int>> loadFromFile(string filename)
    {
        var result = new List<KeyValuePair<string, int>>();
        var lines = File.ReadAllLines(filename);

        if (lines.Length > 0)
        {
            for (int i = 0; i < lines.Length; i += 2)
            {
                result.Add(new KeyValuePair<string, int>(lines[i], Int32.Parse(lines[i + 1])));
            }
        }

        return result;
    }

    private void writeToFile(string filename, List<KeyValuePair<string, int>> scoreBoard)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
        {
            foreach (KeyValuePair<string, int> user in scoreBoard)
            {
                file.WriteLine(user.Key);
                file.WriteLine(user.Value);
            }
        }
    }

    private void sort(List<KeyValuePair<string, int>> scoreBoard)
    {
        scoreBoard.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
    }
}
