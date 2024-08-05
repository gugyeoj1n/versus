using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOctagon : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 10f * Time.deltaTime, 0);
    }
}
