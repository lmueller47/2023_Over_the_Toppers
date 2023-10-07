using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    public bool spawning = false;
    public GameObject rat;

    private void FixedUpdate()
    {
        if (!spawning && GameManager.dirtyCount > 5)
        {
            spawning = true;
            StartCoroutine(Spawn());
        }
    }

    public IEnumerator Spawn()
    {
        Instantiate(rat, transform.position, Quaternion.identity);
        GameManager.dirtyCount += 2;
        yield return new WaitForSeconds(10f);
        spawning = false;
    }
}
