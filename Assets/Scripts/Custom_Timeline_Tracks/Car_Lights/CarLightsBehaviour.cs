using System;
using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    /// <summary>
    /// Class representing the logic part of the Timeline clip for controlling the look of the car lights.
    /// </summary>
    [Serializable]
    public class CarLightsBehaviour : PlayableBehaviour
    {
        /// <summary>
        /// Emission color of the material of the mesh.
        /// </summary>
        [ColorUsage(false, true)] public Color LightMaterialEmissionColor;
        /// <summary>
        /// Intensity of the light source representing the car light.
        /// </summary>
        public float LightIntensity;
    }
}