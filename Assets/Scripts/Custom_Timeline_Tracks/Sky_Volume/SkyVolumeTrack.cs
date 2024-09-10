using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.ComponentModel;

namespace GameDevBuddies
{
    /// <summary>
    /// Class representing the Timeline track for sky volume settings update. It instantiates the 
    /// instance of the <see cref="SkyVolumeMixerBehaviour"/>.
    /// </summary>
    [TrackClipType(typeof(SkyVolumeClip))]
    [TrackBindingType(typeof(SkyVolumeSettings))]
    [DisplayName("GameDevBuddies/Sky Volume Track")]
    public class SkyVolumeTrack : TrackAsset
    {
        /// <inheritdoc/>
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<SkyVolumeMixerBehaviour>.Create(graph, inputCount);
        }
    }
}