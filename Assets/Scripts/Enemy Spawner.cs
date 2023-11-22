using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class EnemySpawner : AttributesSync
{
    public Vector3 spLocation;
    [SynchronizableField] private bool podeSp = false;
    private Spawner _spawner;
    // Start is called before the first frame update
    void Start()
    {
        _spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider col){
        if(col.gameObject.tag == "Player"){
            if(Input.GetKey(KeyCode.E)){
                if(!podeSp){
                    SpawnEnemy();
                    podeSp=true;
                }
            }
        }
    }
    void SpawnEnemy(){
        _spawner.Spawn(0,spLocation,Quaternion.identity);
    }
}
