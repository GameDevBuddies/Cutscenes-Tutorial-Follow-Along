using UnityEngine;

namespace GameDevBuddies
{
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
