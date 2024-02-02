using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject ObstaclePrefab_Red;
    public GameObject ObstaclePrefab_Green;
    public GameObject ObstaclePrefab_Yellow;
    public GameObject ObstaclePrefab_Purple;
    public GameObject ObstaclePrefab_Blue;
    public GameObject ObstaclePrefab_Orange;
    public GameObject ArcPrefab;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.Next_Spawn(true);
        Destroy(gameObject, 2);
    }
    public void SpawnObstacle()
    {
        GameObject[] gameObjects_colors = new GameObject[] { ObstaclePrefab_Red, ObstaclePrefab_Green, ObstaclePrefab_Yellow, ObstaclePrefab_Purple, ObstaclePrefab_Blue, ObstaclePrefab_Orange };
        for (int i=0;i<Random.Range(1,3);i++)
        {
            int SpawnIndex = Random.Range(2, 7);
            Transform spawnPoint = transform.GetChild(SpawnIndex).transform;
            GameObject Obstacle = gameObjects_colors[Random.Range(0, 6)];
            Instantiate(Obstacle, spawnPoint.position, Quaternion.identity, transform);
        }
    }
    public void SpawnArc()
    {
        int ArcToSpawn = 2;
        for (int i=0;i<ArcToSpawn;i++)
        {
            GameObject temp = Instantiate(ArcPrefab,transform);
            temp.transform.position = GetPoint(GetComponent<Collider>());
        }
    }
    Vector3 GetPoint(Collider collider)
    {
        Vector3 point = new Vector3(
                                    Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                                    2,
                                    Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                                    );
        if (point != collider.ClosestPoint(point))
        {
            point = GetPoint(collider);
        }
        return point;
    }
}
