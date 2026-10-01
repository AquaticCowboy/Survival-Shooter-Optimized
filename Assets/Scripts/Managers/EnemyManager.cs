using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public EnemyPool pool;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }
    
    
    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        pool.SpawnAtLocation(spawnPoints[spawnPointIndex].position);
    }
}
