using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    public Vector2 input;
    public int JumpSpeed;

    [Range(0, 2)]
    public int currentLane = 1;
    // ----- Lane 2
    // ----- Lane 1
    // ----- Lane 0
    public Transform[] lanes;
    bool canSwitch = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

    }
    void FixedUpdate()
    {
        Move();
    }
    void ProcessInputs()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");


        input = new Vector2(movex, movey).normalized;
        //Direction of movement
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            canSwitch = true;
        }
    }

    void Move()
    {
        transform.position += new Vector3(input.x * moveSpeed * Time.deltaTime, 0, 0);
        if (input.y > 0 && canSwitch)
        {
            canSwitch = false;
            MoveUpLane();
            // move up a lane
        }
        else if (input.y < 0 && canSwitch)
        {
            canSwitch = false;
            MoveDownLane();
            // move down a lane
        }
    }

    void MoveUpLane()
    {
        if (currentLane < lanes.Length - 1)
        {
            currentLane++;
            SetLanePos(currentLane);

        }
    }

    void MoveDownLane()
    {
        if (currentLane > 0)
        {
            currentLane--;
            SetLanePos(currentLane);
        }
    }

    void SetLanePos(int toSet)
    {
        if (toSet >= 0 && toSet <= 2) // will need to be changed if we change the number of lanes
        {
            transform.position = new Vector2(transform.position.x, lanes[toSet].position.y);
        }
    }

    public float GetMovement() {
        return (input.x * moveSpeed);
    }
}
