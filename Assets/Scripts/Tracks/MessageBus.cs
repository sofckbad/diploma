using System.Collections.Generic;


public class MessageBus
{
    public static List<IListener> listeners;
    
    public static void Reg(IListener r)
    {
        if (listeners == null)
        {
            listeners = new List<IListener>();
        }
        
        listeners.Add(r);
    }
    
    public static void Send(string m)
    {
        foreach (var listener in listeners)
        {
            listener.Send(m);
        }
    }
}


public interface IListener
{
    void Send(string message);
}