using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public GameObject[] hearts;
    public int numberOfHeartsRemaining = 6;

    public static Hud ins;
    // Start is called before the first frame update
    void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHearts() {
        if (numberOfHeartsRemaining > 0)
        {
            numberOfHeartsRemaining--;
            hearts[numberOfHeartsRemaining].SetActive(false);
        }
        else
        {
            Debug.Log("Zero hearts");
        }

    }

    public void IncreaseHearts()
    {
        if (numberOfHeartsRemaining < 6)
        {
            hearts[numberOfHeartsRemaining].SetActive(true);
            numberOfHeartsRemaining++;
        }
        else
        {
            Debug.Log("Maxed out hearts");
        }

    }
}
