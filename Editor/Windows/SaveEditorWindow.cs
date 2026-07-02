using UnityEditor;
using UnityEngine;
using Rula.Persistence.Unity.Editor.Services;
using System.IO;

namespace Rula.Persistence.Unity.Editor.Windows
{
    public sealed class SaveEditorWindow : EditorWindow
    {
        private Vector2 _scrollPosition;
        private string _selectedFilePath;
        
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
                "Persistent Data Path",
                SaveFileService.SaveDirectory);

            GUILayout.Space(10);

            if (GUILayout.Button("Open Save Folder"))
            {
                EditorUtility.RevealInFinder(
                    SaveFileService.SaveDirectory);
            }

            GUILayout.Space(10);

            if (GUILayout.Button("Open Save File"))
            {
                _selectedFilePath = EditorUtility.OpenFilePanel(
                    "Open Save File",
                    SaveFileService.SaveDirectory,
                    string.Empty);
            }

            GUILayout.Space(10);

            EditorGUILayout.LabelField(
                "Selected File",
                string.IsNullOrEmpty(_selectedFilePath)
                    ? "No file selected."
                    : _selectedFilePath);
        }
    }
}