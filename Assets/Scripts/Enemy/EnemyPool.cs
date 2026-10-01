using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{

    [SerializeField] EnemyHealth prefab;
    [SerializeField] int poolSize = 20;

    Queue<EnemyHealth> enemyQueue = new Queue<EnemyHealth>();

    void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            var enemy = Instantiate(prefab);
            enemy.SetPool(this);
            enemy.gameObject.SetActive(false);
        }
    }

    public void SpawnAtLocation(Vector3 location)
    {
        if(enemyQueue.Count > 0)
        {
            var current = enemyQueue.Dequeue();
            current.gameObject.SetActive(true);
            current.transform.position = location;
        }
    }

    public void addToQueue(EnemyHealth e)
    {
        enemyQueue.Enqueue(e);
    }
}
