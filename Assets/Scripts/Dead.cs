using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Player jogador = col.gameObject.GetComponent<Player>();
            if (jogador != null)
            {
                jogador.isDead = true;
            }
        }
    }
}