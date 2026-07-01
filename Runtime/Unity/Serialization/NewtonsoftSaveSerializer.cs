using System;
using Newtonsoft.Json;
using Rula.Persistence.Abstractions;

namespace Rula.Persistence.Unity.Serialization
{
    /// <summary>
    /// Default JSON serializer based on Newtonsoft.Json.
    /// </summary>
    public sealed class NewtonsoftSaveSerializer : ISaveSerializer
    {
        private static readonly JsonSerializerSettings DefaultSettings = new()
        {
#if UNITY_EDITOR
            Formatting = Formatting.Indented
#else
            Formatting = Formatting.None
#endif
        };

        /// <summary>
        /// Serializes the specified object to its JSON representation.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string representing the specified object.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="value"/> is <see langword="null"/>.
        /// </exception>
        public string Serialize<T>(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return JsonConvert.SerializeObject(value, DefaultSettings);
        }

        /// <summary>
        /// Deserializes the specified JSON string to an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="data">The JSON string to deserialize.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="data"/> is <see langword="null"/>, empty, or consists only of whitespace.
        /// </exception>
        /// <exception cref="JsonSerializationException">
        /// Thrown when the JSON cannot be deserialized to the specified type.
        /// </exception>
        public T Deserialize<T>(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("JSON data cannot be null or empty.", nameof(data));

            return JsonConvert.DeserializeObject<T>(data, DefaultSettings)
                   ?? throw new JsonSerializationException(
                       $"Failed to deserialize JSON to {typeof(T).FullName}.");
        }

        /// <summary>
        /// Deserializes the specified JSON string to an instance of the specified type.
        /// </summary>
        /// <param name="data">The JSON string to deserialize.</param>
        /// <param name="type">The target type.</param>
        /// <returns>An object of the specified <paramref name="type"/>.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="data"/> is <see langword="null"/>, empty, or consists only of whitespace.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="type"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="JsonSerializationException">
        /// Thrown when the JSON cannot be deserialized to the specified type.
        /// </exception>
        public object Deserialize(string data, Type type)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("JSON data cannot be null or empty.", nameof(data));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return JsonConvert.DeserializeObject(data, type, DefaultSettings)
                   ?? throw new JsonSerializationException(
                       $"Failed to deserialize JSON to {type.FullName}.");
        }
    }
}