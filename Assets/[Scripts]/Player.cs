using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Status status;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SaveLoadManager.StartWithSave);
        if (SaveLoadManager.StartWithSave)
        {
            PlayerData data = SaveLoadManager.LoadPlayer();
            Vector2 position = new Vector2(data.position[0], data.position[1]);
            transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
