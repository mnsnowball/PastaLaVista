using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    bool levelFailed = false;
    public GameObject levelFailedUI;
    Player player;
    // Start is called before the first frame update
    void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void GameOver() 
    {
        if (!levelFailed)
        {
            levelFailed = true;
            levelFailedUI.SetActive(true);
        }
    }
}
