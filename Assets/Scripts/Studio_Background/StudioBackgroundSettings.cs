using UnityEngine;

namespace GameDevBuddies
{
    /// <summary>
    /// Script responsible for updating the materials for the studio background. It updates them whenever values 
    /// change, both in Editor and in Play mode.
    /// </summary>
    [ExecuteInEditMode]
    public class StudioBackgroundSettings : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private Material _studioBackgroundMaterial = null;

        [Header("Settings: ")]
        [ColorUsage(false, true)] public Color StudioBackgroundTopColor = Color.gray;
        [ColorUsage(false, true)] public Color StudioBackgroundBottomColor = Color.gray;
        [Range(-2, 2)] public float StudioBackgroundHorizonOrigin = 1f;
        [Range(0.1f, 8f)] public float StudioBackgroundGradiantSpread = 4.5f;

        private void Awake()
        {
            UpdateStudioBackgroundSettings();
        }

        private void OnEnable()
        {
            UpdateStudioBackgroundSettings();
        }

        private void OnValidate()
        {
            UpdateStudioBackgroundSettings();
        }

        /// <summary>
        /// Function updates the current material properties in order to update the current look of the studio background.
        /// </summary>
        public void UpdateStudioBackgroundSettings()
        {
            if(_studioBackgroundMaterial == null)
            {
                return;
            }

            _studioBackgroundMaterial.SetColor("_GradientTopColor", StudioBackgroundTopColor);
            _studioBackgroundMaterial.SetColor("_GradientBottomColor", StudioBackgroundBottomColor);
            _studioBackgroundMaterial.SetFloat("_GradientHorizonOrigin", StudioBackgroundHorizonOrigin);
            _studioBackgroundMaterial.SetFloat("_GradientSpread", StudioBackgroundGradiantSpread);
        }
    }
}
