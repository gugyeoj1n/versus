using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HitEffect : MonoBehaviour
{
    void Start()
    {
        DOVirtual.DelayedCall( 0.5f, ( ) => Destroy( gameObject ) );
    }

}
