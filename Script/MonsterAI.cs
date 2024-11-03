using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float chaseDistance = 10f; // Distance at which the monster starts chasing
    public float speed = 3.5f; // Speed of the monster
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed; // Set the speed of the NavMeshAgent
    }

    void Update()
    {
        // Check the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within chase distance, move towards the player
        if (distanceToPlayer < chaseDistance)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            // Optionally, you can make the monster stop or patrol when the player is out of range
            navMeshAgent.ResetPath();
        }
    }
}