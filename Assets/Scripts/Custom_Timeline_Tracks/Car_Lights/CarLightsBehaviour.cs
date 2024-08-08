using System;
using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    [Serializable]
    public class CarLightsBehaviour : PlayableBehaviour
    {
        [ColorUsage(false, true)] public Color LightMaterialEmissionColor;
        public float LightIntensity;
    }
}