using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
public class ReviveDoor : AttributesSync
{
    public Reviver _triger;
    public GameObject porta;
    [SynchronizableField] public bool estaRevivendo;
    private float yMax = 9.07f;
    private float yMin = 1.28f;
    [SynchronizableField] private float yAgora;
    void OnTriggerStay(Collider col){
        if(col.gameObject.tag =="Player"){
            if(Input.GetKey(KeyCode.E)){
                estaRevivendo = true;
                BroadcastRemoteMethod("Update");
            }else{
                estaRevivendo = false;
                BroadcastRemoteMethod("Update");
            }
        }
    }
    [SynchronizableMethod]
    void Update(){
        if(estaRevivendo){
            _triger.Anda();
            yAgora= Mathf.MoveTowards(yAgora, yMax,0.025f);
        }else{
            yAgora= Mathf.MoveTowards(yAgora, yMin,0.025f);
        }
        porta.transform.position= new Vector3 (porta.transform.position.x,yAgora,porta.transform.position.z);
    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.tag =="Player"){
                estaRevivendo = false;  
    }
}
}