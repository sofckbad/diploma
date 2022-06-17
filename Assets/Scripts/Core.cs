using System;
using UnityEngine;
using UnityEngine.Playables;


public class Core : MonoBehaviour
{
    #region Fields
    
    [SerializeField] private PlayableDirector dir;

    #endregion



    #region Properties

    #endregion



    #region Methods
bool o = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.time > 1 && o)
        {
            dir.Play();
            o = false;
        }
    }

    #endregion
}