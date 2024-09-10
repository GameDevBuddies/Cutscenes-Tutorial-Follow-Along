using System;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    /// <summary>
    /// Script representing the logic part of the Timeline clip. 
    /// It exposes a property for controlling the exposure of the sky volume.
    /// </summary>
    [Serializable]
    public class SkyVolumeBehaviour : PlayableBehaviour
    {
        /// <summary>
        /// Exposure of the sky volume.
        /// </summary>
        public float Exposure;
    }
}