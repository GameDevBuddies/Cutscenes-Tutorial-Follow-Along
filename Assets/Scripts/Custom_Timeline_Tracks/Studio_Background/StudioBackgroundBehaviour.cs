using System;
using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    /// <summary>
    /// Class representing the logic part of a single clip on the <see cref="StudioBackgroundTrack"/>.
    /// </summary>
    [Serializable]
    public class StudioBackgroundBehaviour : PlayableBehaviour
    {
        /// <summary>
        /// Bottom color of the studio background gradient.
        /// </summary>
        [ColorUsage(false, true)] public Color StudioBackgroundBottomColor;
        /// <summary>
        /// Top color of the studio background gradient.
        /// </summary>
        [ColorUsage(false, true)] public Color StudioBackgroundTopColor;
        /// <summary>
        /// The origin of the studio background, representing the line connecting the two gradients.
        /// </summary>
        public float StudioBackgroundHorizonOrigin;
        /// <summary>
        /// The spread of the studio background gradient, the greater the value the larger the spread between colors.
        /// </summary>
        public float StudioBackgroundGradiantSpread;
    }
}