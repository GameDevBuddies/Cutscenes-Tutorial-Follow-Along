using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GameDevBuddies
{
    /// <summary>
    /// Script representing the data part of the Timeline clip for controlling the properties of the sky volume.
    /// It's responsible for creating an instance of the <see cref="SkyVolumeBehaviour"/> class.
    /// </summary>
    [Serializable]
    public class SkyVolumeClip : PlayableAsset, ITimelineClipAsset
    {
        /// <summary>
        /// Instance of the <see cref="SkyVolumeBehaviour"/> class, representing the template for creating new clip.
        /// </summary>
        public SkyVolumeBehaviour Template = new SkyVolumeBehaviour();

        /// <summary>
        /// Implementation of the <see cref="ITimelineClipAsset"/> interface.
        /// </summary>
        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        /// <inheritdoc/>
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<SkyVolumeBehaviour>.Create(graph, Template);
        }
    }
}