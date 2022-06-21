using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Exit : MonoBehaviour
{
    #region Fields
    
    [Serializable]
    public class ParticleWithDelay
    {
        public ParticleSystem particle;
        public float time;
    }

    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private List<ParticleWithDelay> particles;
    [SerializeField] private UnityEvent onex;
    private bool isWin;

    #endregion



    #region Properties

    #endregion



    #region Methods

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isWin)
        {
            if ((1 << col.gameObject.layer & playerLayerMask.value) != 0)
            {
                foreach (var particleWithDelay in particles)
                {
                    StartCoroutine(Extention.CallMethodWithDelay(particleWithDelay.particle.Play, particleWithDelay.time));
                }
                isWin = true;
                col.transform.GetComponent<PlayerController>().Disable();
                onex.Invoke();
            }
        }
    }

    #endregion
}