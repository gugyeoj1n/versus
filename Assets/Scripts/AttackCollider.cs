using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class AttackCollider : MonoBehaviour
{
    public Player player;
    public GameObject hitEffect;
    
    private void OnTriggerEnter( Collider other )
    {
        if(other.CompareTag( "Player" ))
            if(player.isAttacking)
            {
                Instantiate( hitEffect, transform.position, Quaternion.identity );
                StartCoroutine( TimeEffect( ) );
            }
    }

    private IEnumerator TimeEffect( )
    {
        Time.timeScale = 0.05f;
        CinemachineVirtualCamera cam = FindObjectOfType<CinemachineVirtualCamera>( );
        DOTween.To(() => cam.m_Lens.FieldOfView, x => cam.m_Lens.FieldOfView = x, 20f, 0.1f);

        yield return new WaitForSeconds( 0.1f );
        
        DOTween.To(() => cam.m_Lens.FieldOfView, x => cam.m_Lens.FieldOfView = x, 60f, 0.1f);
        Time.timeScale = 1f;
    }
}
