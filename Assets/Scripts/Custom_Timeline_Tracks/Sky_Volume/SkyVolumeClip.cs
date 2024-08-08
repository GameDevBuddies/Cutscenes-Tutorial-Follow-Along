using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GameDevBuddies
{
    [Serializable]
    public class SkyVolumeClip : PlayableAsset, ITimelineClipAsset
    {
        public SkyVolumeBehaviour Template = new SkyVolumeBehaviour();

        /// <summary>
        /// Implementation of the <see cref="ITimelineClipAsset"/> interface.
        /// </summary>
        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<SkyVolumeBehaviour>.Create(graph, Template);
        }
    }
}