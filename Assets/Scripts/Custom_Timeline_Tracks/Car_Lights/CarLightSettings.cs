using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace GameDevBuddies
{
    [ExecuteInEditMode]
    public class CarLightSettings : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private Material _carLightMaterial = null;
        [SerializeField] private HDAdditionalLightData[] _carLights = null;

        [Header("Options: ")]
        [ColorUsage(false, true)] public Color LightMaterialEmissionColor = Color.white;
        [Range(0f, 20f)] public float LightIntensity = 14.5f;

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
            UpdateLightIntensity();
            UpdateLightMaterialEmissionColor();
        }

        private void UpdateLightMaterialEmissionColor()
        {
            if(_carLightMaterial == null)
            {
                return;
            }

            _carLightMaterial.SetColor("_EmissiveColor", LightMaterialEmissionColor);
        }

        private void UpdateLightIntensity()
        {
            if (_carLights == null)
            {
                return;
            }

            foreach (HDAdditionalLightData carLight in _carLights)
            {
                carLight.intensity = LightIntensity;
            }
        }
    }
}