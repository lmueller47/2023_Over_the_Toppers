using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatPatrolBehavior : MonoBehaviour
{
    public GameObject[] patrolPoints;
    public int targetPoint;
    public float speed = 10;

    public float currentPosX;
    public float currentPosZ;
    public float lastPosX;
    public float lastPosZ;
    // Start is called before the first frame update
    void Start()
    {
        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
        targetPoint = 0;
        lastPosX = 0;
        lastPosZ = 0;
        GameManager.dirtyCount++;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosX = Mathf.Abs(gameObject.transform.position.x);
        currentPosZ = Mathf.Abs(gameObject.transform.position.z);
        
        if (transform.position == patrolPoints[targetPoint].transform.position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].transform.position, speed * Time.deltaTime);

        if(currentPosX > lastPosX)
        {
            lastPosX = currentPosX;
            gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if(currentPosX < lastPosX)
        {
            lastPosX = currentPosX;
            gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (currentPosZ > lastPosZ)
        {
            lastPosZ = currentPosZ;
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(currentPosZ < lastPosZ)
        {
            lastPosZ = currentPosZ;
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
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
        GameManager.dirtyCount--;
    }
}
