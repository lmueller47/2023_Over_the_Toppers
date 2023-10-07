using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatPatrolBehavior : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
    }
}
