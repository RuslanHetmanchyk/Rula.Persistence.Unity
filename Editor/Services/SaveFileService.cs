using UnityEngine;

namespace Rula.Persistence.Unity.Editor.Services
{
    internal static class SaveFileService
    {
        public static string SaveDirectory => Application.persistentDataPath;
    }
}