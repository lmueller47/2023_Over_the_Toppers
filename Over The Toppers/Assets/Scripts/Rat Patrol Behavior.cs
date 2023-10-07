using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatPatrolBehavior : MonoBehaviour
{
    public GameObject[] patrolPoints;
    public int targetPoint;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolPoints[targetPoint].transform.position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].transform.position, speed * Time.deltaTime);
    }

    void increaseTargetInt()
    {
        targetPoint++;
        if(targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
    private void OnDestroy()
    {
        GameManager.dirtyCount -= 2;
    }
}
