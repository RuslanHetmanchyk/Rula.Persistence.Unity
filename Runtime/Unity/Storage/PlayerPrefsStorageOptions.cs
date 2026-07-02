using System;

namespace Rula.Persistence.Unity.Storage
{
    /// <summary>
    /// Configuration options for <see cref="PlayerPrefsStorage"/>.
    /// </summary>
    public sealed class PlayerPrefsStorageOptions
    {
        /// <summary>
        /// Prefix added to all PlayerPrefs keys.
        /// </summary>
        public string KeyPrefix { get; set; } = string.Empty;
    }
}