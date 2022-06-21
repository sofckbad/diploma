using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class MessageReciever : MonoBehaviour, IListener
{
    #region Fields
    
    [Serializable]
    private class Data
    {
        [SerializeField] public string msg;
        [SerializeField] public UnityEvent evt;
    }
    
    [SerializeField] private List<Data> datas;

    #endregion



    #region Properties

    #endregion



    #region Methods

    private void Awake()
    {
        MessageBus.Reg(this);
    }

    #endregion



    public void Send(string message)
    {
        datas.FirstOrDefault(d => d.msg.Equals(message))?.evt?.Invoke();
    }
}