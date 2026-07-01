using Rula.Persistence.Core;
using Rula.Persistence.Unity.Logging;
using Rula.Persistence.Unity.Serialization;
using Rula.Persistence.Unity.Storage;

namespace Rula.Persistence.Unity.Extensions
{
    /// <summary>
    /// Provides factory methods for creating configured persistence managers.
    /// </summary>
    public static class SaveManagerFactory
    {
        /// <summary>
        /// Creates a SaveManager instance configured for Unity.
        /// </summary>
        /// <returns>
        /// Configured SaveManager instance.
        /// </returns>
        public static SaveManager CreateDefault()
        {
            return new SaveManager(
                new PersistentDataStorage(),
                new NewtonsoftSaveSerializer(),
                new UnityClock(),
                new UnitySaveLogger());
        }
    }
}