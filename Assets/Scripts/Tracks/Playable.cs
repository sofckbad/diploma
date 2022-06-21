using UnityEngine;
using UnityEngine.Playables;


public class Playable : PlayableAsset
{
    [SerializeField] private string sm;
    [SerializeField] private string em;
    
    public override UnityEngine.Playables.Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<PlayableBeh>.Create(graph);
        playable.GetBehaviour().Initialize(sm, em);
        return playable;
    }
}