using System;
using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    [Serializable]
    public class StudioBackgroundBehaviour : PlayableBehaviour
    {
        [ColorUsage(false, true)] public Color StudioBackgroundBottomColor;
        [ColorUsage(false, true)] public Color StudioBackgroundTopColor;
        public float StudioBackgroundHorizonOrigin;
        public float StudioBackgroundGradiantSpread;
    }
}