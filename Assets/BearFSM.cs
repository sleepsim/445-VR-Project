using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BearFSM : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Transform spawnPoint;
    public LayerMask whatIsGround, whatIsPlayer, whatIsSpawn;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float talkRange;
    public float sightRange;
    public float spawnPointRange;

    public bool withinBounds;
    public bool resetComplete;
    public bool playerInSightRange;
    public bool playerInTalkRange;

    [Header("Animator")]
    public Animator lLeg, rLeg, lArm, rArm;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        resetComplete = true;
    }
    private void Update()
    {
        withinBounds = Physics.CheckSphere(transform.position, spawnPointRange, whatIsSpawn);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInTalkRange = Physics.CheckSphere(transform.position, talkRange, whatIsPlayer);

        //Debug.Log("resetComplete dawg " + resetComplete);
        //Debug.Log("playerinsight dawg " + playerInSightRange);
        //Debug.Log("First " + (!withinBounds && !resetComplete));
        //Debug.Log("Second " + (!playerInSightRange && resetComplete));
        //Debug.Log("Third " + (playerInSightRange && resetComplete));

        //if (!withinBounds && !resetComplete) ReturnToSpawn();
        //else if (!playerInSightRange && resetComplete) Patrolling();
        //else if (playerInSightRange && resetComplete) ChasePlayer();

        if (!playerInSightRange && !playerInTalkRange)
        {
            enableAnim();
            Patrolling();
        }
        if (playerInSightRange && !playerInTalkRange)
        {
            enableAnim();
            ChasePlayer();
        }
        if (playerInTalkRange && playerInSightRange)
        {
            disableAnim();
            TalkToPlayer();
        }

        //Debug.Log("walkpoint vector " + walkPoint);
        //Debug.Log("Current Position " + transform.position);
    }

    private void ReturnToSpawn()
    {
        resetComplete = false;
        agent.SetDestination(spawnPoint.position);

        Vector3 distanceToSpawn = transform.position - spawnPoint.position;
        Debug.Log(distanceToSpawn);

        if(distanceToSpawn.magnitude < 1f) resetComplete = true;
    }

    private void Patrolling()
    {
        //if (!walkPointSet) SearchWalkPoint();
        if (!walkPointSet)
        {
            walkPoint = RandomNavmeshLocation(7);
            walkPointSet = true;
        }

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Debug.Log("walkpoint set" + walkPointSet);
        //Debug.Log(distanceToWalkPoint.magnitude);
        //Debug.Log("vect dist" + Vector3.Distance(transform.position, walkPoint));

        if (distanceToWalkPoint.magnitude < 3f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        //float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        //walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //if(Physics.Raycast(walkPoint, Vector3.down, 5f, whatIsGround)) walkPointSet = true;

        //Debug.Log("Test if okay " + (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)));

        Vector3 randomDirection = Random.insideUnitSphere * walkPointRange;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkPointRange, 1);
        Vector3 finalPosition = hit.position;

        Debug.Log("New Walkpoint Set ahaha");
        walkPointSet = true;

    }

    public Vector3 RandomNavmeshLocation(float radius)
    {

        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;  // Offset the position by the object's current position

        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
        {
            finalPosition = hit.position; // Get the valid position found on the NavMesh
        }
        else
        {
            // If no valid position was found, log the failure.
            Debug.LogWarning("No valid NavMesh position found within the given radius.");
        }

        return finalPosition; // Return the valid position, or Vector3.zero if no valid position was found
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void TalkToPlayer()
    {
        agent.SetDestination(transform.position);

        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, talkRange);
        Gizmos.color= Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
    private void disableAnim()
    {
        rLeg.Rebind();
        lLeg.Rebind();
        rArm.Rebind();
        lArm.Rebind();

        rLeg.enabled = false;
        lLeg.enabled = false;
        rArm.enabled = false;
        lArm.enabled = false;
    }
    private void enableAnim()
    {
        rLeg.enabled = true;
        lLeg.enabled = true;
        rArm.enabled = true;
        lArm.enabled = true;
    }
}
