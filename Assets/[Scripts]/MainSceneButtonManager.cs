using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneButtonManager : MonoBehaviour
{

    public GameObject ButtonPannel;
    public GameObject LoadingPannel;
    public Slider LoadingSlider;

    public void OnClickNewGame()
    {
        ButtonPannel.SetActive(false);
        LoadingPannel.SetActive(true);
        StartCoroutine(LoadingAsync());

    }

    public void OnClickContinue()
    {
        SaveLoadManager.StartWithSave = true;
        SceneManager.LoadScene("PlayScene", UnityEngine.SceneManagement.LoadSceneMode.Single);

    }

    IEnumerator LoadingAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("PlayScene", UnityEngine.SceneManagement.LoadSceneMode.Single);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingSlider.value = progress;
            yield return null;
        }

    }



    public void OnClickExit()
    {

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

}
