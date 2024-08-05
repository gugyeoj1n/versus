using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleUIManager : MonoBehaviour
{
    public RectTransform titleText;
    public RectTransform subtitleText;
    public Transform touchText;
    
    void Start()
    {
        TitleAnimation( );
    }

    private void TitleAnimation( )
    {
        Vector2 offScreenLeft = new Vector2(-Screen.width / 2 - titleText.rect.width, titleText.anchoredPosition.y);
        Vector2 offScreenRight = new Vector2(Screen.width / 2 + subtitleText.rect.width, subtitleText.anchoredPosition.y);

        titleText.anchoredPosition = offScreenLeft;
        subtitleText.anchoredPosition = offScreenRight;
        
        titleText.gameObject.SetActive( true );
        subtitleText.gameObject.SetActive( true );

        Vector2 centerPosition = new Vector2(0, titleText.anchoredPosition.y);

        var seq = DOTween.Sequence();

        seq.AppendInterval( 1f )
            .Append( titleText.DOAnchorPos( centerPosition + Vector2.up * 30f, 1f ) )
            .Join( subtitleText.DOAnchorPos( centerPosition - Vector2.up * 60f, 1f ) )
            .OnComplete( ( ) =>
            {
                touchText.gameObject.SetActive( true );
                touchText.transform.DOMoveY( touchText.transform.position.y + 30f, 2f )
                    .SetLoops( -1, LoopType.Yoyo )
                    .SetEase( Ease.InOutSine );
            } );

        seq.Play( );
    }
}
