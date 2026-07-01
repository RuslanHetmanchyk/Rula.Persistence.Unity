namespace Rula.Persistence.Unity.Storage
{
    /// <summary>
    /// Provides a base path for persistent save data.
    /// </summary>
    public interface IPersistentPathProvider
    {
        /// <summary>
        /// Gets the persistent root path.
        /// </summary>
        string Path { get; }
    }
}