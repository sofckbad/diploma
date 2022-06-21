using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class DelayedCall : MonoBehaviour
{
    #region Fields
[SerializeField] private UnityEvent evt;
    #endregion



    #region Properties

    #endregion



    #region Methods
    
    public void Call(float t)
    {
        StartCoroutine(C(t));
    }


    private IEnumerator C(float t)
    {
        yield return new WaitForSeconds(t);
        evt?.Invoke();
    }

    #endregion
}