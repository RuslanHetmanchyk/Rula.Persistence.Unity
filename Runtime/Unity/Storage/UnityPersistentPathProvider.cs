using UnityEngine;

namespace Rula.Persistence.Unity.Storage
{
    /// <summary>
    /// Provides a persistent path using Application.persistentDataPath.
    /// </summary>
    public sealed class UnityPersistentPathProvider : IPersistentPathProvider
    {
        /// <inheritdoc />
        public string Path => Application.persistentDataPath;
    }
}