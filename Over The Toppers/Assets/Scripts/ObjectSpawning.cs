using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectSpawning : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObjectSpawning Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Dictionary<string, Queue<GameObject>> poolDictonary;
    public List<Pool> pools;
    private void Start()
    {
        poolDictonary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);  
            }

            poolDictonary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {

        if(!poolDictonary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
        GameObject objectToSpawn = poolDictonary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictonary[tag].Enqueue(objectToSpawn); 

        return objectToSpawn;
    }
}
