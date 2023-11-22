using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Alteruna;

public class Enemy : AttributesSync
{
    public List<Player> players = new List<Player>();
    private NavMeshAgent agent;
    [SynchronizableField] public float averagePlayerSpeed = 0f;
    public Player closestPlayer;

    void Start()
    {
        FindPlayers();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
    }

    void Update()
    {
        if (players.Count > 0)
        {
            float Speed = 0f;
            closestPlayer = FindClosestPlayer();
            foreach (var player in players)
            {
                Speed += player.IsMoving;
            }
            averagePlayerSpeed = Speed;
            agent.destination =  closestPlayer.transform.position;
            agent.speed = averagePlayerSpeed;
        }
    }
    void FindPlayers()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (var playerObject in playerObjects)
        {
            Player playerComponent = playerObject.GetComponent<Player>();
            if (playerComponent != null)
            {
                players.Add(playerComponent);
            }
        }
    }

        Player FindClosestPlayer()
    {
        Player closestPlayer = null;
        float closestDistance = Mathf.Infinity;
        Vector3 enemyPosition = transform.position;

        foreach (var player in players)
        {
            float distanceToPlayer = Vector3.Distance(enemyPosition, player.transform.position);
            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }
}