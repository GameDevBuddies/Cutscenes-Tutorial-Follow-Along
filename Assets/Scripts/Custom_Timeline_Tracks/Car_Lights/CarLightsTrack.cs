using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.ComponentModel;

namespace GameDevBuddies
{
    [TrackClipType(typeof(CarLightsClip))]
    [TrackBindingType(typeof(CarLightSettings))]
    [DisplayName("GameDevBuddies/Car Light Settings Track")]
    public class CarLightsTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<CarLightsMixerBehaviour>.Create(graph, inputCount);
        }
    }
}