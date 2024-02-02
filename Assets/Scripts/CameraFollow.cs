using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 start_pos;
    public Transform player;
    void Start()
    {
        start_pos = transform.position - player.position;
    }
    void Update()
    {
        Vector3 CameraPos= player.position + start_pos;
        CameraPos.x = 0;
        transform.position = CameraPos;
    }
}
