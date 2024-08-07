using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HitEffect : MonoBehaviour
{
    void Start()
    {
        DOVirtual.DelayedCall( 2f, ( ) => Destroy( gameObject ) );
    }

}
