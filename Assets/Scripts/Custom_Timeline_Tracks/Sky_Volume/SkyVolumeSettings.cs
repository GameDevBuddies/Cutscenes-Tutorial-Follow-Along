using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace GameDevBuddies
{
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
