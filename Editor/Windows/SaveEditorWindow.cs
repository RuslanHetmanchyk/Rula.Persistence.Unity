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
        private string _fileContent = string.Empty;
        
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
                OpenSaveFile();
            }

            using (new EditorGUI.DisabledScope(string.IsNullOrEmpty(_selectedFilePath)))
            {
                if (GUILayout.Button("Reload"))
                {
                    ReloadFile();
                }
            }

            GUILayout.Space(10);

            EditorGUILayout.LabelField(
                "Selected File",
                string.IsNullOrEmpty(_selectedFilePath)
                    ? "No file selected."
                    : _selectedFilePath);
            
            GUILayout.Space(10);

            GUILayout.Label("Content", EditorStyles.boldLabel);

            _fileContent = EditorGUILayout.TextArea(
                _fileContent,
                GUILayout.ExpandHeight(true));
        }
        
        private void OpenSaveFile()
        {
            string filePath = EditorUtility.OpenFilePanel(
                "Open Save File",
                SaveFileService.SaveDirectory,
                string.Empty);

            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            _selectedFilePath = filePath;
            _fileContent = File.ReadAllText(filePath);
        }

        private void ReloadFile()
        {
            if (string.IsNullOrEmpty(_selectedFilePath))
            {
                return;
            }

            if (!File.Exists(_selectedFilePath))
            {
                EditorUtility.DisplayDialog(
                    "File not found",
                    "The selected save file no longer exists.",
                    "OK");

                return;
            }

            _fileContent = File.ReadAllText(_selectedFilePath);
        }
    }
}