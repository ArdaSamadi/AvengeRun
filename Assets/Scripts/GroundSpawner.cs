using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 next_spawn_point;
    public void Next_Spawn(bool spawnItems)
    {
        GameObject temp =Instantiate(groundTile, next_spawn_point, Quaternion.identity);
        next_spawn_point = temp.transform.GetChild(1).transform.position;
        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnArc();
        }
    }
    void Start()
    {
        for (int i=0;i<3;i++)
        {
            Next_Spawn(false);
        }
        for (int i=0;i<10;i++)
        {
            Next_Spawn(true);
        }
    }
}
