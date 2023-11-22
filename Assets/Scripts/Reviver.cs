using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Reviver : MonoBehaviour
{
    public Player jogador;
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            jogador=col.gameObject.GetComponent<Player>();
        }
    }
    public void Anda(){
        if(jogador != null){
            jogador.isDead = false;
        }
    }
}