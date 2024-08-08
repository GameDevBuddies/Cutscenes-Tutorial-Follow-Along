using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GameDevBuddies
{
    [Serializable]
    public class CarLightsClip : PlayableAsset, ITimelineClipAsset
    {
        public CarLightsBehaviour Template = new CarLightsBehaviour();

        /// <summary>
        /// Implementation of the <see cref="ITimelineClipAsset"/> interface.
        /// </summary>
        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<CarLightsBehaviour>.Create(graph, Template);
        }
    }
}