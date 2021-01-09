using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject PauseScreen;
    public string MainMenuString;

    public GameObject loadingScreen;
    public GameObject loadingIcon, loadingIcon2, loadingIcon3;
    public Text LoadingScreenText;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }
    public void Resume()
    {
        if (!isPaused)
        {
            PauseScreen.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            PauseScreen.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene(MainMenuString);
        StartCoroutine(LoadMain());
    }

    public void CloseOptions()
    {
        OptionsMenu.SetActive(false);
    }

    public void OpenMenuOptions()
    {
        OptionsMenu.SetActive(true);
    }

    public IEnumerator LoadMain()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(MainMenuString);

        asyncLoad.allowSceneActivation = false;

        while(!asyncLoad.isDone)
        {
            if(asyncLoad.progress >= .9f)
            {
                LoadingScreenText.text = "Press any key to continue";
                loadingIcon.SetActive(false);
                loadingIcon2.SetActive(false);
                loadingIcon3.SetActive(false);
                if(Input.anyKey)
                {
                    asyncLoad.allowSceneActivation = true;
                    Time.timeScale = 1f;
                }
            }

            yield return null;
        }

    }
}
