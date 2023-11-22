using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class UltiPorta : AttributesSync
{
    public ProgressBar[] barras;
    [SynchronizableField] public int tarefa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tarefa == barras.Length){
            transform.position= new Vector3(transform.position.x, 9.07f,transform.position.z);
        }
    }
}
