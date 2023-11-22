using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouBurro : MonoBehaviour
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
        float forwardSpeed = Input.GetAxis("Vertical");
        float sideSpeed = Input.GetAxis("Horizontal");
        if(forwardSpeed != 0f || sideSpeed !=0){
            animacao.SetBool("Corendo",true);
        }else{
            animacao.SetBool("Corendo",false);
        }
    }
}
