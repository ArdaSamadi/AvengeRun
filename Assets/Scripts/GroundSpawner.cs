using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject[] Buildings;
    GameObject temp2;
    GameObject temp3;
    int count = 0;
    Vector3 next_spawn_point;
    public void Next_Spawn(bool spawnItems)
    {
        
        GameObject temp =Instantiate(groundTile, next_spawn_point, Quaternion.identity);
        next_spawn_point = temp.transform.GetChild(1).transform.position;
        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnArc();
            count++;
            if (count == 20)
            {
                Destroy(temp3);
                temp3 = temp2;
                temp2 = Instantiate(Buildings[(int)Random.Range(0, Buildings.Length - 1)], new Vector3(next_spawn_point.x - 30.2f, next_spawn_point.y, next_spawn_point.z+100),Quaternion.Euler(0f,90f,0f));
                temp2.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
                count = 0;
            }
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
