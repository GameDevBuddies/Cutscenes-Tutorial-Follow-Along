using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    public class CarLightsMixerBehaviour : PlayableBehaviour
    {
        private Color _defaultLightMaterialEmissiveColor;
        private float _defaultLightIntensity;

        private Color _assignedLightMaterialEmissiveColor;
        private float _assignedLightIntensity;

        private CarLightSettings _carLightSettingsBinding;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            _carLightSettingsBinding = playerData as CarLightSettings;
            if (_carLightSettingsBinding == null)
            {
                return;
            }

            // Updating default values based on the current and assigned values.
            if (_carLightSettingsBinding.LightMaterialEmissionColor != _assignedLightMaterialEmissiveColor)
            {
                _defaultLightMaterialEmissiveColor = _carLightSettingsBinding.LightMaterialEmissionColor;
            }
            if (!Mathf.Approximately(_carLightSettingsBinding.LightIntensity, _assignedLightIntensity))
            {
                _defaultLightIntensity = _carLightSettingsBinding.LightIntensity;
            }

            // Get number of car lights clips on the track.
            int inputCount = playable.GetInputCount();

            // Helper variables required for interpolation process.
            Color blendedEmissiveColor = Color.clear;
            float blendedLightIntensity = 0f;
            float totalWeight = 0f;

            // Going over all clips on the track and updating their influence to the final blended values.
            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<CarLightsBehaviour> inputPlayable = (ScriptPlayable<CarLightsBehaviour>)playable.GetInput(i);
                CarLightsBehaviour input = inputPlayable.GetBehaviour();

                blendedEmissiveColor += input.LightMaterialEmissionColor * inputWeight;
                blendedLightIntensity += input.LightIntensity * inputWeight;
                totalWeight += inputWeight;
            }

            // Updating assigned values.
            _assignedLightMaterialEmissiveColor = blendedEmissiveColor + _defaultLightMaterialEmissiveColor * (1f - totalWeight);
            _assignedLightIntensity = blendedLightIntensity + _defaultLightIntensity * (1f - totalWeight);

            // Updating values on the car lights binding and triggering refresh on the background.
            _carLightSettingsBinding.LightMaterialEmissionColor = _assignedLightMaterialEmissiveColor;
            _carLightSettingsBinding.LightIntensity = _assignedLightIntensity;

            _carLightSettingsBinding.UpdateSettings();
        }
    }
}