using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneUIManager : MonoBehaviour
{
    public GameObject Player;

    public GameObject TransitionObject;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBgm("PlayScene", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSave()
    {
        SaveLoadManager.SavePlayer(Player.GetComponent<Player>());
    }

    public void OnClickLoad()
    {
        PlayerData data = SaveLoadManager.LoadPlayer();
        Vector2 savedPosition = new Vector2(data.position[0], data.position[1]);
        Player.transform.position = savedPosition;
    }

    public void PlayTransitionIn()
    {
        TransitionObject.GetComponent<Animator>().Play("transition");
    }
    public void PlayTransitionOut()
    {
        TransitionObject.GetComponent<Animator>().Play("transition3");
    }
}
