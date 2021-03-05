using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    bool levelFailed = false;
    public GameObject levelFailedUI;
    Player player;
    PlayerController controller;
    Enemy[] enemies;
    //Pickup[] pickups;
    // Start is called before the first frame update
    void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        enemies = GameObject.FindObjectsOfType<Enemy>();
        // pickups = GameObject.FindObjectsOfType<Pickup>();
    }

    public void GameOver() 
    {
        if (!levelFailed)
        {
            levelFailed = true;
            levelFailedUI.SetActive(true);
        }
    }

    public void ResetLevel() {
        player.transform.position = player.lastCheckpoint.transform.position;
        player.RestoreHealth(player.maxHearts);
        CameraFollow.ins.ResetPosition();
        RespawnEnemies();
        levelFailedUI.SetActive(false);
        // RespawnPickups();
    }

    public void RespawnEnemies() {
        foreach (Enemy enemy in enemies)
        {
            enemy.gameObject.SetActive(true);
            enemy.Respawn();
        }
    }

    /*
     public void RespawnPickups() {
        foreach (Pickup p in pickups)
        {
            p.gameObject.SetActive(true);
            //p.Respawn();
        }
    }
     */
}
