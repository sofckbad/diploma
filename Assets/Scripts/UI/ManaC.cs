using System;
using UnityEngine;


public class ManaC :MonoBehaviour
{
    [SerializeField] private RectTransform v;
    [SerializeField] private float vst;
    [SerializeField] private float q;
    [SerializeField] private float qs;
    float c = 1;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            c -= q;
        }
        
        c = Mathf.Clamp01(c + qs * Time.deltaTime);
        
        v.SetWidth(vst * c);
    }

}