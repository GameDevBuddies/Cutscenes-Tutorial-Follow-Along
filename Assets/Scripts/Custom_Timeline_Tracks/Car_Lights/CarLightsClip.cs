using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GameDevBuddies
{
    /// <summary>
    /// Class responsible for creating an instance of the <see cref="CarLightsBehaviour"/> component.
    /// </summary>
    [Serializable]
    public class CarLightsClip : PlayableAsset, ITimelineClipAsset
    {
        /// <summary>
        /// Instance of the <see cref="CarLightsBehaviour"/> class, representing the template for creating new clip.
        /// </summary>
        public CarLightsBehaviour Template = new CarLightsBehaviour();

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
            return ScriptPlayable<CarLightsBehaviour>.Create(graph, Template);
        }
    }
}