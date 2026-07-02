using UnityEditor;
using UnityEngine;

namespace Rula.Persistence.Unity.Editor.Windows
{
    public sealed class SaveEditorWindow : EditorWindow
    {
        [MenuItem("Tools/Rula/Persistence/Save Editor")]
        public static void Open()
        {
            GetWindow<SaveEditorWindow>("Save Editor");
        }

        private void OnGUI()
        {
            GUILayout.Label("Rula Persistence Save Editor", EditorStyles.boldLabel);
            GUILayout.Space(10);

            GUILayout.Label("Coming soon...");
        }
    }
}