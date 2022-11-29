using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadBattleScene()
    {
        FindObjectOfType<PlaySceneUIManager>().PlayTransitionIn();
        LoadLevelByName("BattleScene");
        SoundManager.Instance.PlayBgm("BattleScene", 2.0f);
    }


    public void LoadLevelByName(string name, float delay = 0.0f)
    {
        FindObjectOfType<DataTransfer>().SetPlayerStatusForBattle();
        StartCoroutine(LoadBattleSceneDelay(name, 0.2f));
    }

    IEnumerator LoadBattleSceneDelay(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
    
}
