using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace GameDevBuddies
{
    /// <summary>
    /// Component responsible for updating the exposure property of the referenced sky volume profile.
    /// </summary>
    [ExecuteInEditMode]
    public class SkyVolumeSettings : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private VolumeProfile _skyVolumeProfile = null;

        [Header("Options: ")]
        public float Exposure = 2f;

        private void Awake()
        {
            UpdateSettings();
        }

        private void OnEnable()
        {
            UpdateSettings();
        }

        private void OnValidate()
        {
            UpdateSettings();
        }

        /// <summary>
        /// Function updates the current settings of the referenced <see cref="VolumeProfile"/>.
        /// </summary>
        public void UpdateSettings()
        {
            if(_skyVolumeProfile == null)
            {
                return;
            }

            foreach(VolumeComponent volumeComponent in _skyVolumeProfile.components)
            {
                if(volumeComponent is HDRISky hdrSky)
                {
                    hdrSky.exposure.SetValue(new FloatParameter(Exposure));
                }
            }
        } 
    }
}
