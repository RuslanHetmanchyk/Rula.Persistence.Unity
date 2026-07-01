using Rula.Persistence.Abstractions;
using UnityEngine;

namespace Rula.Persistence.Unity.Logging
{
    /// <summary>
    /// Unity implementation of persistence logging.
    /// </summary>
    public sealed class UnitySaveLogger : ISaveLogger
    {
        /// <inheritdoc />
        public void Log(string message)
        {
            Debug.Log(message);
        }

        /// <inheritdoc />
        public void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }

        /// <inheritdoc />
        public void LogError(string message)
        {
            Debug.LogError(message);
        }
    }
}