using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.ComponentModel;

namespace GameDevBuddies
{
    /// <summary>
    /// Component representing the Timeline track for updating the car lights. It's responsible
    /// for spawning the <see cref="CarLightsMixerBehaviour"/> instance on the track.
    /// </summary>
    [TrackClipType(typeof(CarLightsClip))]
    [TrackBindingType(typeof(CarLightSettings))]
    [DisplayName("GameDevBuddies/Car Light Settings Track")]
    public class CarLightsTrack : TrackAsset
    {
        /// <inheritdoc/>
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<CarLightsMixerBehaviour>.Create(graph, inputCount);
        }
    }
}