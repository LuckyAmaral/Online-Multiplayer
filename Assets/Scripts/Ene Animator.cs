using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneAnimator : MonoBehaviour
{
    private Animator animacao;
    // Start is called before the first frame update
    void Start()
    {
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            animacao.SetBool("taAtacando",true);
        }
    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            animacao.SetBool("taAtacando",false);
        }
    }
}
