using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


[Serializable]
[TrackClipType(typeof(Playable))]
[TrackBindingType(typeof(CinemachineVirtualCamera), TrackBindingFlags.None)]
[TrackColor(0.53f, 0.0f, 0.08f)]
public class Track : TrackAsset
{
    public override UnityEngine.Playables.Playable CreateTrackMixer(
        PlayableGraph graph,
        GameObject go,
        int inputCount)
    {
        var mixer = ScriptPlayable<PlayableMixer>.Create(graph);
        mixer.SetInputCount(inputCount);
        return mixer;
    }
}