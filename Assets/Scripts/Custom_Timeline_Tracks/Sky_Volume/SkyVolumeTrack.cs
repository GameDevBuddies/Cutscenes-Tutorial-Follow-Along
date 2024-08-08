using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.ComponentModel;

namespace GameDevBuddies
{
    [TrackClipType(typeof(SkyVolumeClip))]
    [TrackBindingType(typeof(SkyVolumeSettings))]
    [DisplayName("GameDevBuddies/Sky Volume Track")]
    public class SkyVolumeTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<SkyVolumeMixerBehaviour>.Create(graph, inputCount);
        }
    }
}