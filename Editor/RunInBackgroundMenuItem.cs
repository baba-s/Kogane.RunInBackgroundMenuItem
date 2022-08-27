using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class RunInBackgroundMenuItem
    {
        private const string MENU_ITEM_NAME = "Kogane/Run In Background";

        static RunInBackgroundMenuItem()
        {
            EditorApplication.delayCall            += () => UpdateChecked();
            EditorApplication.playModeStateChanged += _ => UpdateChecked();
        }

        [MenuItem( MENU_ITEM_NAME )]
        private static void Change()
        {
            PlayerSettings.runInBackground = !PlayerSettings.runInBackground;

            foreach ( var editorWindow in Resources.FindObjectsOfTypeAll<EditorWindow>() )
            {
                editorWindow.Repaint();
            }

            UpdateChecked();
        }

        private static void UpdateChecked()
        {
            Menu.SetChecked( MENU_ITEM_NAME, PlayerSettings.runInBackground );
        }
    }
}