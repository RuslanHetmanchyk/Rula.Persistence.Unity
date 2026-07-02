using UnityEditor;
using UnityEngine;
using Rula.Persistence.Unity.Editor.Services;

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

            EditorGUILayout.LabelField(
                "Save Directory",
                SaveFileService.SaveDirectory);

            GUILayout.Space(10);

            if (GUILayout.Button("Open Save Folder"))
            {
                UnityEditor.EditorUtility.RevealInFinder(
                    SaveFileService.SaveDirectory);
            }
        }
    }
}