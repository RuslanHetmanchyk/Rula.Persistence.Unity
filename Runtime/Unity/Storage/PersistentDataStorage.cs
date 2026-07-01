using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Rula.Persistence.Abstractions;

namespace Rula.Persistence.Unity.Storage
{
    /// <summary>
    /// File-based save storage using a persistent path provider.
    /// </summary>
    public sealed class PersistentDataStorage : ISaveStorage
    {
        private readonly PersistentDataStorageOptions _options;
        private readonly IPersistentPathProvider _pathProvider;

        /// <summary>
        /// Initializes a new instance of <see cref="PersistentDataStorage"/>.
        /// </summary>
        /// <param name="options">
        /// Storage configuration options.
        /// </param>
        /// <param name="pathProvider">
        /// Provider used to resolve the persistent storage path.
        /// </param>
        public PersistentDataStorage(
            PersistentDataStorageOptions options,
            IPersistentPathProvider pathProvider)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _pathProvider = pathProvider ?? throw new ArgumentNullException(nameof(pathProvider));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PersistentDataStorage"/>
        /// using the default options and Unity persistent data path.
        /// </summary>
        public PersistentDataStorage()
            : this(
                new PersistentDataStorageOptions(),
                new UnityPersistentPathProvider())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PersistentDataStorage"/>
        /// using the specified options and the default Unity persistent data path.
        /// </summary>
        public PersistentDataStorage(
            PersistentDataStorageOptions options)
            : this(
                options,
                new UnityPersistentPathProvider())
        {
        }

        /// <inheritdoc />
        public async Task SaveAsync(
            string slot,
            string data,
            CancellationToken token = default)
        {
            if (slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var path = GetFilePath(slot);

            EnsureDirectoryExists(path);

            await File.WriteAllTextAsync(
                path,
                data,
                token);
        }

        /// <inheritdoc />
        public async Task<string> LoadAsync(
            string slot,
            CancellationToken token = default)
        {
            if (slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            var path = GetFilePath(slot);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                    $"Save slot '{slot}' was not found.",
                    path);
            }

            return await File.ReadAllTextAsync(
                path,
                token);
        }

        /// <inheritdoc />
        public bool Exists(
            string slot)
        {
            if (slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            return File.Exists(GetFilePath(slot));
        }

        /// <inheritdoc />
        public void Delete(
            string slot)
        {
            if (slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            var path = GetFilePath(slot);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private string GetFilePath(
            string slot)
        {
            var extension = NormalizeExtension(_options.FileExtension);

            var directoryPath = Path.Combine(
                _pathProvider.Path,
                _options.DirectoryName);

            return Path.Combine(
                directoryPath,
                $"{slot}{extension}");
        }

        private void EnsureDirectoryExists(
            string filePath)
        {
            if (!_options.CreateDirectoryIfMissing)
            {
                return;
            }

            var directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static string NormalizeExtension(
            string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
            {
                return string.Empty;
            }

            return extension.StartsWith(".")
                ? extension
                : $".{extension}";
        }
    }
}