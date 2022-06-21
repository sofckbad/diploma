using System;
using UnityEngine;
using UnityEngine.Events;


public class PrButton : MonoBehaviour
{
    #region Fields
    
    [SerializeField] private UnityEvent onTriggered;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isAutoDisable;
    [SerializeField] private LayerMask mask;

    private int Play = Animator.StringToHash("play");
    private int Back = Animator.StringToHash("back");
    private bool isDeactivated;
    #endregion



    #region Properties

    #endregion



    #region Methods

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (1 << col.gameObject.layer != mask.value)
        {
            return;
        }
        if (isDeactivated)
        {
            return;
        }

        animator.SetTrigger(Play);

        if (isAutoDisable)
        {
            isDeactivated = true;
        }
        else
        {
            animator.SetTrigger(Back);
        }
        
        onTriggered?.Invoke();
    }
    
    public void Deactivate()
    {
        isDeactivated = true;
        animator.ResetTrigger(Play);
        animator.ResetTrigger(Back);
        animator.SetTrigger(Play);
    }

    #endregion
}