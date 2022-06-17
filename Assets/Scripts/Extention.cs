using System;
using System.Collections;
using UnityEngine;


public static class Extention
{
    public static IEnumerator CallMethodWithDelay(Action callback, float time)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }
}