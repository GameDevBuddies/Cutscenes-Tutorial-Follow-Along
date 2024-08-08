using UnityEngine.Playables;

namespace GameDevBuddies
{
    public class SkyVolumeMixerBehaviour : PlayableBehaviour
    {
        private float _defaultExposure;

        private float _assignedExposure;

        private SkyVolumeSettings _skyVolumeSettingsBinding;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            _skyVolumeSettingsBinding = playerData as SkyVolumeSettings;
            if (_skyVolumeSettingsBinding == null)
            {
                return;
            }

            // Updating default values based on the current and assigned values.
            if (_skyVolumeSettingsBinding.Exposure != _assignedExposure)
            {
                _defaultExposure = _skyVolumeSettingsBinding.Exposure;
            }

            // Get number of clips on the track.
            int inputCount = playable.GetInputCount();

            // Helper variables required for interpolation process.
            float blendedExposure = 0f;
            float totalWeight = 0f;

            // Going over all clips on the track and updating their influence to the final blended values.
            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<SkyVolumeBehaviour> inputPlayable = (ScriptPlayable<SkyVolumeBehaviour>)playable.GetInput(i);
                SkyVolumeBehaviour input = inputPlayable.GetBehaviour();

                blendedExposure += input.Exposure * inputWeight;
                totalWeight += inputWeight;
            }

            // Updating assigned values.
            _assignedExposure = blendedExposure + _defaultExposure * (1f - totalWeight);

            // Updating values on the binding and triggering refresh on the background.
            _skyVolumeSettingsBinding.Exposure = _assignedExposure;
            _skyVolumeSettingsBinding.UpdateSettings();
        }
    }
}