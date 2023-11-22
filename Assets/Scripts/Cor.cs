using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cor : MonoBehaviour
{    
public Material[] cor;
public List<Player> players = new List<Player>();
public Player worker;
    // Start is called before the first frame update
    void Start()
    {
    FindPlayers();
    GetComponent<Renderer>().material = cor[players.Count-1];
    worker = players[players.Count-1];
    worker.atividade = players.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
