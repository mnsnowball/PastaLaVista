using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Range(0f,1f)]
    public float followStrength = 0.75f;
    public Rigidbody2D rb;

    public void SetVelocity(float toSet) 
    {
        rb.velocity = new Vector2(toSet * followStrength, 0);
    }
}
