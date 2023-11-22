using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
public class Portao : AttributesSync
{
    private float yMax = 9.07f;
    private float yMin = 1.28f;
    private float yAgora;
    public GameObject porta;
    public bool aberto;
    public Portao lado;
    public float destino = 9.07f;
    void Start()
    {
        yAgora = yMax;
    }

    // Update is called once per frame
    [SynchronizableMethod]
    void Update()
    {
        porta.transform.position = new Vector3(porta.transform.position.x, yAgora, porta.transform.position.z);
        yAgora =  Mathf.MoveTowards(yAgora, destino,0.025f);
        if(yAgora == yMax){
            aberto = false;
            lado.aberto = false;
        }
        if(yAgora == yMin){
            aberto = true;
            lado.aberto = true;
        }
    }



    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Entrou");
            if (Input.GetKey(KeyCode.E))
            {
                if (aberto == true)
                {
                    destino=yMax;
                    BroadcastRemoteMethod("Update");     
                }
                else if (aberto == false)
                {
                    destino=yMin;
                    BroadcastRemoteMethod("Update");
                }
            }
        }
    }
}