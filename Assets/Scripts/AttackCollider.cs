using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Player player;
    
    private void OnTriggerEnter( Collider other )
    {
        if(other.CompareTag( "Player" ))
            if(player.isAttacking)
                Debug.Log( "HIT" );
    }
}
