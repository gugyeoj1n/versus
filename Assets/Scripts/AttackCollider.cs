using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Player player;
    public GameObject hitEffect;
    
    private void OnTriggerEnter( Collider other )
    {
        if(other.CompareTag( "Player" ))
            if(player.isAttacking)
            {
                Debug.Log( "HIT" );
                Instantiate( hitEffect, transform.position, Quaternion.identity );
            }
    }
}
