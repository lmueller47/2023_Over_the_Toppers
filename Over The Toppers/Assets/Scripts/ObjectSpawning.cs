using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    public GameObject[] toppings;
    public Transform[] spawnPoint;

    public float spawnTime = 1;
    public bool spawning = false;

    // Update is called once per frame
    void Update()
    {
        if(!spawning)
        {
            StartCoroutine(Toppings());
        }
    }

    public IEnumerator Toppings()
    {
        spawning = true;
        Spawn();
        yield return new WaitForSeconds(spawnTime);
        spawning = false;
    }

    void Spawn()
    {
        int chosenSpawn = Random.Range(0, spawnPoint.Length);
        Instantiate(toppings[Random.Range(0, toppings.Length)], spawnPoint[chosenSpawn].position, Quaternion.identity); 
    }
}
