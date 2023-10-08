using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawning = false;
    public GameObject topping;
    private void FixedUpdate()
    {
        if(!spawning)
        {
            spawning = true;
            StartCoroutine(Spawn());
        }
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(3/((GameManager.inspectionsPassed * .5f) + 1), 20/((GameManager.inspectionsPassed * .5f) + 1)));
        Instantiate(topping, transform.position, Quaternion.identity);
        spawning = false;
    }
}
