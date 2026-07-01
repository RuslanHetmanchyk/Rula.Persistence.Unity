namespace Rula.Persistence.Unity.Storage
{
    /// <summary>
    /// Configuration for PersistentDataStorage.
    /// </summary>
    public sealed class PersistentDataStorageOptions
    {
        /// <summary>
        /// Relative directory inside the persistent root path.
        /// </summary>
        public string DirectoryName { get; set; } = "Saves";

        /// <summary>
        /// Extension used for save files.
        /// </summary>
        public string FileExtension { get; set; } = ".json";

        /// <summary>
        /// Creates the save directory automatically when needed.
        /// </summary>
        public bool CreateDirectoryIfMissing { get; set; } = true;
    }
}