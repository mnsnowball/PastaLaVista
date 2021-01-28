using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hearts = 6;              // amount of hits the player can take
    public int maxHearts = 6;           // maximum amount of hearts
    public float moveSpeedMod = 1f;     // can be powered up or slowed
    public int lives = 3;               // amount of times the player can restart at a checkpoint before starting over
    public int maxLives = 5;            // player cannot exceed this many lives

    void IncreaseLives()
    {
        if (lives < maxLives)
        {
            lives++;
        }
    }

    void DecreaseLives() 
    {
        if (lives > 0)
        {
            lives--;
            // show in hud
        }

        if (lives == 0)
        {
            // play death animation
            // reload level after a sec
        }
    }

    void DecreaseHearts(int decreaseAmount) {
        if (hearts > 0)
        {
            hearts-= decreaseAmount;
            // show hearts decreasing in UI
        }
        if (hearts == 0)
        {
            // GameManager.ins.GameOver();
            // play death animation
        }
    }

    void IncreaseHearts(int increaseAmount) 
    {
        if (hearts + increaseAmount > maxHearts)
        {
            hearts = maxHearts;
            
        }
        else
        {
            hearts += increaseAmount;
        }

        // animate hearts restoring
    }

    public void TakeDamage(int damageAmount) 
    {
        Debug.Log("Player taking " + damageAmount + " damage");
    }
}
