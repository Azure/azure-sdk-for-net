// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Azure.Extensions.AspNetCore.Configuration.Secrets
{
    /// <summary>
    /// An AzureKeyVault based <see cref="ConfigurationProvider"/>.
    /// </summary>
    internal class AzureKeyVaultConfigurationProvider : ConfigurationProvider, IDisposable
    {
        private readonly TimeSpan? _reloadInterval;
        private readonly SecretClient _client;
        private readonly KeyVaultSecretManager _manager;
        private Dictionary<string, LoadedSecret> _loadedSecrets;
        private Task _pollingTask;
        private readonly CancellationTokenSource _cancellationToken;

        /// <summary>
        /// Creates a new instance of <see cref="AzureKeyVaultConfigurationProvider"/>.
        /// </summary>
        /// <param name="client">The <see cref="SecretClient"/> to use for retrieving values.</param>
        /// <param name="manager">The <see cref="KeyVaultSecretManager"/> to use in managing values.</param>
        /// <param name="reloadInterval">The timespan to wait in between each attempt at polling the Azure Key Vault for changes. Default is null which indicates no reloading.</param>
        public AzureKeyVaultConfigurationProvider(SecretClient client, KeyVaultSecretManager manager, TimeSpan? reloadInterval = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(manager, nameof(manager));

            _client = client;
            _manager = manager;
            if (reloadInterval != null && reloadInterval.Value <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(reloadInterval), reloadInterval, nameof(reloadInterval) + " must be positive.");
            }

            _pollingTask = null;
            _cancellationToken = new CancellationTokenSource();
            _reloadInterval = reloadInterval;
        }

        /// <summary>
        /// Load secrets into this provider.
        /// </summary>
        public override void Load() => LoadAsync().GetAwaiter().GetResult();

        private async Task PollForSecretChangesAsync()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                await WaitForReload().ConfigureAwait(false);
                try
                {
                    await LoadAsync().ConfigureAwait(false);
                }
                catch (Exception)
                {
                    // Ignore
                }
            }
        }

        protected virtual Task WaitForReload()
        {
            // WaitForReload is only called when the _reloadInterval has a value.
            return Task.Delay(_reloadInterval.Value, _cancellationToken.Token);
        }

        private async Task LoadAsync()
        {
            var secretPages = _client.GetPropertiesOfSecretsAsync();

            using var secretLoader = new ParallelSecretLoader(_client);
            var newLoadedSecrets = new Dictionary<string, LoadedSecret>();
            var oldLoadedSecrets = Interlocked.Exchange(ref _loadedSecrets, null);

            await foreach (var secret in secretPages.ConfigureAwait(false))
            {
                if (!_manager.Load(secret) || secret.Enabled != true)
                {
                    continue;
                }

                var secretId = secret.Name;
                if (oldLoadedSecrets != null &&
                    oldLoadedSecrets.TryGetValue(secretId, out var existingSecret) &&
                    existingSecret.IsUpToDate(secret.UpdatedOn))
                {
                    oldLoadedSecrets.Remove(secretId);
                    newLoadedSecrets.Add(secretId, existingSecret);
                }
                else
                {
                    secretLoader.Add(secret.Name);
                }
            }

            var loadedSecret = await secretLoader.WaitForAll().ConfigureAwait(false);
            foreach (var secretBundle in loadedSecret)
            {
                newLoadedSecrets.Add(secretBundle.Value.Name, new LoadedSecret(_manager.GetKey(secretBundle), secretBundle.Value.Value, secretBundle.Value.Properties.UpdatedOn));
            }

            _loadedSecrets = newLoadedSecrets;

            // Reload is needed if we are loading secrets that were not loaded before or
            // secret that was loaded previously is not available anymore
            if (loadedSecret.Any() || oldLoadedSecrets?.Any() == true)
            {
                SetData(_loadedSecrets, fireToken: oldLoadedSecrets != null);
            }

            // schedule a polling task only if none exists and a valid delay is specified
            if (_pollingTask == null && _reloadInterval != null)
            {
                _pollingTask = PollForSecretChangesAsync();
            }
        }

        private void SetData(Dictionary<string, LoadedSecret> loadedSecrets, bool fireToken)
        {
            var data = new Dictionary<string, string>(loadedSecrets.Count, StringComparer.OrdinalIgnoreCase);
            foreach (var secretItem in loadedSecrets)
            {
                data.Add(secretItem.Value.Key, secretItem.Value.Value);
            }

            Data = data;
            if (fireToken)
            {
                OnReload();
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _cancellationToken.Cancel();
            _cancellationToken.Dispose();
        }

        private readonly struct LoadedSecret
        {
            public LoadedSecret(string key, string value, DateTimeOffset? updated)
            {
                Key = key;
                Value = value;
                Updated = updated;
            }

            public string Key { get; }
            public string Value { get; }
            public DateTimeOffset? Updated { get; }

            public bool IsUpToDate(DateTimeOffset? updated)
            {
                if (updated.HasValue != Updated.HasValue)
                {
                    return false;
                }

                return updated.GetValueOrDefault() == Updated.GetValueOrDefault();
            }
        }
    }
}
