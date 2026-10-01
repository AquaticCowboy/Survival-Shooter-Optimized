using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent _agent;
    EnemyHealth enemyHealth;
    Transform player;
    PlayerHealth playerHealth;
    float elapsed = 0;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        player = FindFirstObjectByType<PlayerMovement>().transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update ()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 0.1)
        {
            elapsed = 0;
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                _agent.SetDestination(player.position);
            }
            else
            {
                _agent.enabled = false;
            }
        }
    }
}
