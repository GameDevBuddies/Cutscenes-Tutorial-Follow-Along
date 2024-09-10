using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace GameDevBuddies
{
    /// <summary>
    /// Component responsible for updating the properties of the referenced lights and material. 
    /// It updates them whenever any of the properties change, both in Editor and in the Play mode.
    /// </summary>
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

        /// <summary>
        /// Function updates both the light settings and the material properties in order to 
        /// apply changes to the car light.
        /// </summary>
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