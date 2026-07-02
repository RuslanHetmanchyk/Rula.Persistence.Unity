using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rula.Persistence.Abstractions;
using UnityEngine;

namespace Rula.Persistence.Unity.Storage
{
    /// <summary>
    /// Stores save data using Unity PlayerPrefs.
    /// </summary>
    public sealed class PlayerPrefsStorage : ISaveStorage
    {
        private readonly PlayerPrefsStorageOptions _options;

        public PlayerPrefsStorage(
            PlayerPrefsStorageOptions? options = null)
        {
            _options = options ?? new PlayerPrefsStorageOptions();
        }

        public Task SaveAsync(
            string slot,
            string data,
            CancellationToken token = default)
        {
            if (slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            token.ThrowIfCancellationRequested();

            PlayerPrefs.SetString(
                GetKey(slot),
                data);

            PlayerPrefs.Save();

            return Task.CompletedTask;
        }

        public Task<string> LoadAsync(
            string slot,
            CancellationToken token = default)
        {
            if (slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            token.ThrowIfCancellationRequested();

            string key = GetKey(slot);

            if (!PlayerPrefs.HasKey(key))
            {
                throw new KeyNotFoundException(
                    $"Save slot '{slot}' was not found.");
            }

            return Task.FromResult(
                PlayerPrefs.GetString(key));
        }

        public bool Exists(string slot)
        {
            if (slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            return PlayerPrefs.HasKey(GetKey(slot));
        }

        public void Delete(string slot)
        {
            if (slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            string key = GetKey(slot);

            if (!PlayerPrefs.HasKey(key))
            {
                return;
            }

            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();
        }

        private string GetKey(string slot)
        {
            return string.Concat(_options.KeyPrefix, slot);
        }
    }
}