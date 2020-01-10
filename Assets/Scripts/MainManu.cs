using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainManu : MonoBehaviour
{
    public string firstLevel;
    public string secondLevel;
    public string leaderBoard;
    public string upgrade;


    public GameObject optionScreen;

    public GameObject loadingScreen, loadingIcon;
    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // SceneManager.LoadScene(firstLevel);
        StartCoroutine(LoadStart());
    }

    public void StartLevel2()
    {
        // SceneManager.LoadScene(firstLevel);
        StartCoroutine(LoadStartLevel2());
    }

    public IEnumerator LoadStartLevel2()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(secondLevel);

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

    public void OpenOptions()
    {
        optionScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator LoadStart()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(firstLevel);

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

    public void LeaderBoard()
    {
        // SceneManager.LoadScene(firstLevel);
        StartCoroutine(LoadLeaderBoard());
    }

    public IEnumerator LoadLeaderBoard()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(leaderBoard);

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

    public void Upgrade()
    {
        StartCoroutine(LoadUpgrade());
    }

    public IEnumerator LoadUpgrade()
    {
        loadingScreen.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(upgrade);

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
}
