using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameDevBuddies
{
    /// <summary>
    /// Custom editor window for choosing predefined custom layouts that ease the creation of game cinematics.
    /// </summary>
    public class CinematicLayoutsSelectionWindow: EditorWindow
    {
        private static readonly string LAYOUTS_PATH = "Assets/Data/Layouts/";
        private static readonly string CINEMATIC_LAYOUT_PATH = LAYOUTS_PATH + "CinematicToolbox.wlt";
        private static readonly string ANIMATION_LAYOUT_PATH = LAYOUTS_PATH + "CinematicToolboxAnimation.wlt";
        private static readonly string LIGHTING_LAYOUT_PATH = LAYOUTS_PATH + "CinematicToolboxLighting.wlt";
        private static readonly string AUDIO_LAYOUT_PATH = LAYOUTS_PATH + "CinematicToolboxAudio.wlt";

        /// <summary>
        /// Function adds option to the Windows menu for spawning this window.
        /// </summary>
        [MenuItem("Window/Cinematic Helpers/Layout Selection")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<CinematicLayoutsSelectionWindow>(false, "Layouts Selection");
        }

        /// <inheritdoc/>
        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Layouts");
            GUILayout.BeginVertical();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Cinematic"))
            {
                LoadCustomLayout(CINEMATIC_LAYOUT_PATH);
            }
            if (GUILayout.Button("Animation"))
            {
                LoadCustomLayout(ANIMATION_LAYOUT_PATH);
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Lighting"))
            {
                LoadCustomLayout(LIGHTING_LAYOUT_PATH);
            }

            if (GUILayout.Button("Audio"))
            {
                LoadCustomLayout(AUDIO_LAYOUT_PATH);
            }
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        private static void LoadCustomLayout(string layoutPath)
        {
            if (File.Exists(layoutPath))
            {
                EditorUtility.LoadWindowLayout(layoutPath);
            }
            else
            {
                Debug.LogWarning("Layout not loaded. Layout file missing at: " + layoutPath);
            }
        }
    }
}
