using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARC : MonoBehaviour
{
    public float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.name != "Player")
        {
            return;
        }
        GameManager.inst.ADD_score();
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
