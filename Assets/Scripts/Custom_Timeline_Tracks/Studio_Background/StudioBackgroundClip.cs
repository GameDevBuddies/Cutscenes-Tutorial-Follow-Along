using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GameDevBuddies
{
    [Serializable]
    public class StudioBackgroundClip : PlayableAsset, ITimelineClipAsset
    {
        public StudioBackgroundBehaviour Template = new StudioBackgroundBehaviour();

        /// <summary>
        /// Implementation of the <see cref="ITimelineClipAsset"/> interface.
        /// </summary>
        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<StudioBackgroundBehaviour>.Create(graph, Template);
        }
    }
}