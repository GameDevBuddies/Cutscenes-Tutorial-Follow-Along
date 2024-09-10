using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.ComponentModel;

namespace GameDevBuddies
{
    /// <summary>
    /// Class responsible for spawning the <see cref="StudioBackgroundMixerBehaviour"/> instance.
    /// It represents the Timeline track that accepts the clips of <see cref="StudioBackgroundClip"/> type.
    /// </summary>
    [TrackClipType(typeof(StudioBackgroundClip))]
    [TrackBindingType(typeof(StudioBackgroundSettings))]
    [DisplayName("GameDevBuddies/Studio Background Track")]
    public class StudioBackgroundTrack : TrackAsset
    {
        /// <inheritdoc/>
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<StudioBackgroundMixerBehaviour>.Create(graph, inputCount);
        }
    }
}