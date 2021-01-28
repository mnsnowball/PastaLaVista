using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {Patrol, Idle, Charging, Telegraphing}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;         // controls current state
    public bool hasPatrol;
    public List<Transform> patrolPoints;    // only used in the patrol state
    public float timeToTelegraph = 1.5f;        // number of seconds enemy takes to charge up before they attack
    public float moveSpeed = 4f;
    float telegraphTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                //patrol
                break;
            case EnemyState.Idle:
                // just do idle animation
                break;
            case EnemyState.Charging:
                Charge();
                break;
            case EnemyState.Telegraphing:
                Telegraph();
                // if we're not already telegraphing, trigger the animation
                // add to the telegraphing timer
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // change scale to face the left
            // change state to telegraphing
            if (currentState != EnemyState.Charging && currentState != EnemyState.Telegraphing)
            {
                ChangeState(EnemyState.Telegraphing);
            }
            
        }
    }

    private void ChangeState(EnemyState toSet) 
    {
        currentState = toSet;
    }

    void Telegraph() 
    {
        Debug.Log("Telegraphing");
        telegraphTimer += Time.deltaTime;
        if (telegraphTimer >= timeToTelegraph)
        {
            ChangeState(EnemyState.Charging);
        }
    }

    void Charge() 
    {
        Debug.Log("Charging");
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
    }
}
