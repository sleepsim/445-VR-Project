using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

        if (!playerInSightRange && !playerInTalkRange) Patrolling();
        if (playerInSightRange && !playerInTalkRange) ChasePlayer();
        if (playerInTalkRange && playerInSightRange) TalkToPlayer();


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
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Debug.Log("walkpoint set" + walkPointSet);
        //Debug.Log(distanceToWalkPoint);

        if (distanceToWalkPoint.magnitude < 1.5f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, Vector3.down, 5f, whatIsGround)) walkPointSet = true;

        Debug.Log("Test if okay " + (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)));

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void TalkToPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, talkRange);
        Gizmos.color= Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}
