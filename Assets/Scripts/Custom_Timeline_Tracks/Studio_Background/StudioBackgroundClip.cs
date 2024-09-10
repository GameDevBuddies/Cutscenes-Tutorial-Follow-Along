using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GameDevBuddies
{
    /// <summary>
    /// Class responsible for spawning the <see cref="StudioBackgroundBehaviour"/> clip on the track.
    /// </summary>
    [Serializable]
    public class StudioBackgroundClip : PlayableAsset, ITimelineClipAsset
    {
        /// <summary>
        /// Instance of the <see cref="StudioBackgroundBehaviour"/> that serves as a template for creating a new instance.
        /// </summary>
        public StudioBackgroundBehaviour Template = new StudioBackgroundBehaviour();

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
            return ScriptPlayable<StudioBackgroundBehaviour>.Create(graph, Template);
        }
    }
}