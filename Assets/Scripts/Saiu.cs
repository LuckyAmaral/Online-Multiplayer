using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Alteruna;
public class Saiu : AttributesSync
{
    [SynchronizableField] public int condicao;
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            condicao+=1;
        }
    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            condicao-=1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(condicao == 4){
            SceneManager.LoadScene("Final");
        }
    }
}
