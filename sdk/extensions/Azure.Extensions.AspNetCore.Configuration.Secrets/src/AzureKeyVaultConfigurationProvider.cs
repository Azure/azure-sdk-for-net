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
    public class AzureKeyVaultConfigurationProvider : ConfigurationProvider, IDisposable
    {
        private readonly TimeSpan? _reloadInterval;
        private readonly SecretClient _client;
        private readonly KeyVaultSecretManager _manager;
        private Dictionary<string, KeyVaultSecret> _loadedSecrets;
        private Task _pollingTask;
        private readonly CancellationTokenSource _cancellationToken;

        /// <summary>
        /// Creates a new instance of <see cref="AzureKeyVaultConfigurationProvider"/>.
        /// </summary>
        /// <param name="client">The <see cref="SecretClient"/> to use for retrieving values.</param>
        /// <param name="options">The <see cref="AzureKeyVaultConfigurationOptions"/> to configure provider behaviors.</param>
        /// <exception cref="ArgumentNullException">When either <paramref name="client"/> or <see cref="AzureKeyVaultConfigurationOptions.Manager"/> is <code>null</code>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When either <see cref="AzureKeyVaultConfigurationOptions.ReloadInterval"/> is not positive or <code>null</code>.</exception>
        public AzureKeyVaultConfigurationProvider(SecretClient client, AzureKeyVaultConfigurationOptions options = null)
        {
            options ??= new AzureKeyVaultConfigurationOptions();
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(options.Manager, $"{nameof(options)}.{nameof(options.Manager)}");

            _client = client;
            if (options.ReloadInterval != null && options.ReloadInterval.Value <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(options.ReloadInterval), options.ReloadInterval, nameof(options.ReloadInterval) + " must be positive.");
            }

            _pollingTask = null;
            _cancellationToken = new CancellationTokenSource();
            _reloadInterval = options.ReloadInterval;
            _manager = options.Manager;
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

        internal virtual Task WaitForReload()
        {
            // WaitForReload is only called when the _reloadInterval has a value.
            return Task.Delay(_reloadInterval.Value, _cancellationToken.Token);
        }

        private async Task LoadAsync()
        {
            var secretPages = _client.GetPropertiesOfSecretsAsync();

            using var secretLoader = new ParallelSecretLoader(_client);
            var newLoadedSecrets = new Dictionary<string, KeyVaultSecret>();
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
                    IsUpToDate(existingSecret, secret))
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
                newLoadedSecrets.Add(secretBundle.Value.Name, secretBundle);
            }

            _loadedSecrets = newLoadedSecrets;

            // Reload is needed if we are loading secrets that were not loaded before or
            // secret that was loaded previously is not available anymore
            if (loadedSecret.Any() || oldLoadedSecrets?.Any() == true)
            {
                Data = _manager.GetData(newLoadedSecrets.Values);
                if (oldLoadedSecrets != null)
                {
                    OnReload();
                }
            }

            // schedule a polling task only if none exists and a valid delay is specified
            if (_pollingTask == null && _reloadInterval != null)
            {
                _pollingTask = PollForSecretChangesAsync();
            }
        }

        /// <summary>
        /// Frees resources held by the <see cref="AzureKeyVaultConfigurationProvider"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Frees resources held by the <see cref="AzureKeyVaultConfigurationProvider"/> object.
        /// </summary>
        /// <param name="disposing">true if called from <see cref="Dispose()"/>, otherwise false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cancellationToken.Cancel();
                _cancellationToken.Dispose();
            }
        }

        private static bool IsUpToDate(KeyVaultSecret current, SecretProperties updated)
        {
            if (updated.UpdatedOn.HasValue != current.Properties.UpdatedOn.HasValue)
            {
                return false;
            }

            return updated.UpdatedOn.GetValueOrDefault() == current.Properties.UpdatedOn.GetValueOrDefault();
        }
    }
}
