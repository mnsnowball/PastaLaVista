using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow ins;
    Transform player;
    Vector3 offset;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    public void ResetPosition() {
        transform.position = player.transform.position + offset;
    }
}
