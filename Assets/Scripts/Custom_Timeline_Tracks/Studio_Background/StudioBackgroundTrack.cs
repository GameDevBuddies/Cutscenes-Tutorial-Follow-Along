using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.ComponentModel;

namespace GameDevBuddies
{
    [TrackClipType(typeof(StudioBackgroundClip))]
    [TrackBindingType(typeof(StudioBackgroundSettings))]
    [DisplayName("GameDevBuddies/Studio Background Track")]
    public class StudioBackgroundTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<StudioBackgroundMixerBehaviour>.Create(graph, inputCount);
        }
    }
}