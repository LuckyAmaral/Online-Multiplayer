using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alteruna;
public class ProgressBar : AttributesSync
{
    public GameObject progresso;
    public Slider slider;
    public float valor;
    public int interacao;
    public Player jogador;
    public UltiPorta porta;
    [SynchronizableField] public bool inativo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(valor == 100 && inativo == false){
            porta.tarefa = porta.tarefa + 1;
            inativo = true;
        }
    }
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            progresso.SetActive(true);
            slider.value = valor;
            jogador = col.gameObject.GetComponent<Player>();
        }
    }
    void OnTriggerStay(Collider col){
        if(col.gameObject.tag == "Player"){
            if(jogador.atividade == interacao){
                if(Input.GetMouseButton(0)){
                    jogador.Xies = 4.5f;
                    slider.value = valor;
                    valor= Mathf.MoveTowards(valor, 100.0f,0.05f);
                }else{
                    jogador.Xies = 0f;
                }
            } 
        }
    }
    
    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            progresso.SetActive(false);
        }
    }

}