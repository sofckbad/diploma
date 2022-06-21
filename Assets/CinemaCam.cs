using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaCam : MonoBehaviour
{
    public static CinemaCam instance;
    [SerializeField] private Animator animator;
    private static readonly int InHash = Animator.StringToHash("in");
    private static readonly int OutHash = Animator.StringToHash("out");
    private void Awake()
    {
        instance = this;
    }
    
    public static void In()
    {
        instance.animator.SetTrigger(InHash);
    }
    
    public static void Out()
    {
        instance.animator.SetTrigger(OutHash);
    }
}
