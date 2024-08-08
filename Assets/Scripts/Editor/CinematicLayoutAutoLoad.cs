using System.IO;
using UnityEditor;

namespace GameDevBuddies
{
    /// <summary>
    /// Class that initializes the layout for the cinematic edit as soon as the Unity loads.
    /// </summary>
    [InitializeOnLoad]
    public class CinematicLayoutAutoLoad
    {
        private static string CINEMATIC_LAYOUT_PATH = "Assets/Data/Layouts/CinematicToolbox.wlt";
        private static string LAYOUT_APPLIED_PATH = "Library/CinematicLayoutApplied";

        /// <summary>
        /// Constructor that checks if the Library contains the file that suggests that the layout has been 
        /// loaded already, and loads the layout if necessary.
        /// </summary>
        static CinematicLayoutAutoLoad()
        {
            if (!File.Exists(LAYOUT_APPLIED_PATH))
            {
                EditorApplication.delayCall += LoadCinematicLayout;
            }
        }

        /// <summary>
        /// Function loads the cinematic layout from the file and applies it to the editor.
        /// </summary>
        private static void LoadCinematicLayout()
        {
            if(!File.Exists(LAYOUT_APPLIED_PATH) && File.Exists(CINEMATIC_LAYOUT_PATH))
            {
                EditorUtility.LoadWindowLayout(CINEMATIC_LAYOUT_PATH);
                File.Create(LAYOUT_APPLIED_PATH).Dispose();
            }
        }
    }
}
