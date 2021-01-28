using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public ParallaxLayer[] layers;
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        for (int layerIndex = 0; layerIndex < layers.Length; layerIndex++)
        {
            layers[layerIndex].SetVelocity(player.GetMovement());
        }
    }
}
