using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string FirstLevel;
    public GameObject ClosedOptions;

    public GameObject loadingScreen;
    public GameObject loadingIcon, loadingIcon2, loadingIcon3;
    public Text LoadingScreenText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Resumegame()
    {

    }

    public void StartGame()
    {
        //SceneManager.LoadScene(FirstLevel);
        StartCoroutine(LoadMain());
    }

    public void OpenOptions()
    {
       ClosedOptions.SetActive(true);
    }

    public void CloseOptions()
    {
        ClosedOptions.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator LoadMain()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(FirstLevel);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                LoadingScreenText.text = "Press any key to continue";
                loadingIcon.SetActive(false);
                loadingIcon2.SetActive(false);
                loadingIcon3.SetActive(false);
                if (Input.anyKey)
                {
                    asyncLoad.allowSceneActivation = true;
                    Time.timeScale = 1f;
                }
            }

            yield return null;
        }

    }
}
