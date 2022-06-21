using UnityEngine.Playables;


public class PlayableBeh : PlayableBehaviour
{
    private string sm;
    private string em;


    public void Initialize(string startMsg, string endMsg)
    {
        sm = startMsg;
        em = endMsg;
    }


    public override void OnGraphStart(UnityEngine.Playables.Playable playable)
    {
        base.OnGraphStart(playable);
     
        MessageBus.Send(sm);
    }


    public override void OnGraphStop(UnityEngine.Playables.Playable playable)
    {
        base.OnGraphStop(playable);
        
        MessageBus.Send(em);
    }
}