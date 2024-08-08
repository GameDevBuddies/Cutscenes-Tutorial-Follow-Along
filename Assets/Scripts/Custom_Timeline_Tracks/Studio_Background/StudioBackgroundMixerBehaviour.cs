using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    public class StudioBackgroundMixerBehaviour : PlayableBehaviour
    {
        private Color _defaultStudioBackgroundBottomColor;
        private Color _defaultStudioBackgroundTopColor;
        private float _defaultStudioBackgroundHorizonOrigin;
        private float _defaultStudioBackgroundGradiantSpread;

        private Color _assignedStudioBackgroundBottomColor;
        private Color _assignedStudioBackgroundTopColor;
        private float _assignedStudioBackgroundHorizonOrigin;
        private float _assignedStudioBackgroundGradiantSpread;

        private StudioBackgroundSettings _studioBackgroundSettingsBinding;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            _studioBackgroundSettingsBinding = playerData as StudioBackgroundSettings;
            if(_studioBackgroundSettingsBinding == null)
            {
                return;
            }

            // Updating default values based on the current and assigned values.
            if(_studioBackgroundSettingsBinding.StudioBackgroundBottomColor != _assignedStudioBackgroundBottomColor)
            {
                _defaultStudioBackgroundBottomColor = _studioBackgroundSettingsBinding.StudioBackgroundBottomColor;
            }
            if (_studioBackgroundSettingsBinding.StudioBackgroundTopColor != _assignedStudioBackgroundTopColor)
            {
                _defaultStudioBackgroundTopColor = _studioBackgroundSettingsBinding.StudioBackgroundTopColor;
            }
            if (!Mathf.Approximately(_studioBackgroundSettingsBinding.StudioBackgroundHorizonOrigin, _assignedStudioBackgroundHorizonOrigin))
            {
                _defaultStudioBackgroundHorizonOrigin = _studioBackgroundSettingsBinding.StudioBackgroundHorizonOrigin;
            }
            if (!Mathf.Approximately(_studioBackgroundSettingsBinding.StudioBackgroundGradiantSpread, _assignedStudioBackgroundGradiantSpread))
            {
                _defaultStudioBackgroundGradiantSpread = _studioBackgroundSettingsBinding.StudioBackgroundGradiantSpread;
            }

            // Get number of studio background clips on the track.
            int inputCount = playable.GetInputCount();

            // Helper variables required for interpolation process.
            Color blendedBottomColor = Color.clear;
            Color blendedTopColor = Color.clear;
            float blendedHorizonOrigin = 0f;
            float blendedGradiantSpread = 0f;
            float totalWeight = 0f;

            // Going over all clips on the track and updating their influence to the final blended values.
            for(int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<StudioBackgroundBehaviour> inputPlayable = (ScriptPlayable<StudioBackgroundBehaviour>)playable.GetInput(i);
                StudioBackgroundBehaviour input = inputPlayable.GetBehaviour();

                blendedBottomColor += input.StudioBackgroundBottomColor * inputWeight;
                blendedTopColor += input.StudioBackgroundTopColor * inputWeight;
                blendedHorizonOrigin += input.StudioBackgroundHorizonOrigin * inputWeight;
                blendedGradiantSpread += input.StudioBackgroundGradiantSpread * inputWeight;
                totalWeight += inputWeight;
            }

            // Updating assigned values.
            _assignedStudioBackgroundBottomColor = blendedBottomColor + _defaultStudioBackgroundBottomColor * (1f - totalWeight);
            _assignedStudioBackgroundTopColor = blendedTopColor + _defaultStudioBackgroundTopColor * (1f - totalWeight);
            _assignedStudioBackgroundHorizonOrigin = blendedHorizonOrigin + _defaultStudioBackgroundHorizonOrigin * (1f - totalWeight);
            _assignedStudioBackgroundGradiantSpread = blendedGradiantSpread + _defaultStudioBackgroundGradiantSpread * (1f - totalWeight);

            // Updating values on the studio background binding and triggering refresh on the background.
            _studioBackgroundSettingsBinding.StudioBackgroundBottomColor = _assignedStudioBackgroundBottomColor;
            _studioBackgroundSettingsBinding.StudioBackgroundTopColor = _assignedStudioBackgroundTopColor;
            _studioBackgroundSettingsBinding.StudioBackgroundHorizonOrigin = _assignedStudioBackgroundHorizonOrigin;
            _studioBackgroundSettingsBinding.StudioBackgroundGradiantSpread = _assignedStudioBackgroundGradiantSpread;
            _studioBackgroundSettingsBinding.UpdateStudioBackgroundSettings();
        }
    }
}