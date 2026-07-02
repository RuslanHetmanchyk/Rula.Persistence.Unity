using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Rula.Persistence.Unity.Editor.Services
{
    internal static class SaveFileService
    {
        public static string SaveDirectory => Application.persistentDataPath;

        public static IReadOnlyList<string> GetSaveFiles()
        {
            if (!Directory.Exists(SaveDirectory))
            {
                return new List<string>();
            }

            return Directory.GetFiles(SaveDirectory);
        }
    }
}