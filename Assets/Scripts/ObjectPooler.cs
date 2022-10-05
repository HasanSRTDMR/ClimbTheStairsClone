using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> poolStairs;
        public GameObject stair;
        public int poolSize;
    }
    public static ObjectPooler Instance;
    [SerializeField] Pool[] pools;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].poolStairs = new Queue<GameObject>();

            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].stair);
                obj.SetActive(false);
                pools[j].poolStairs.Enqueue(obj);
            }
        }
    }

    public GameObject GetPoolObject(int objectType, Vector3 position, Quaternion rotation)
    {
        if (objectType >= pools.Length)
        {
            return null;
        }
        GameObject go = pools[objectType].poolStairs.Dequeue();
        go.SetActive(true);
        go.transform.position = position;
        go.transform.rotation = rotation;
        pools[objectType].poolStairs.Enqueue(go);
        return go;
    }
}
