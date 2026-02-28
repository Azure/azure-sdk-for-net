// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Data.AppConfiguration;

namespace Microsoft.Extensions.Configuration.AppConfiguration
{
    /// <summary>
    /// An Azure App Configuration based <see cref="ConfigurationProvider"/>.
    /// </summary>
    internal class AppConfigurationProvider : ConfigurationProvider, IDisposable
    {
        private readonly TimeSpan? _reloadInterval;
        private readonly ConfigurationClient _client;
        private readonly AppConfigurationSettingManager _manager;
        private readonly SettingSelector _selector;
        private Dictionary<string, ConfigurationSetting> _loadedSettings;
        private Task _pollingTask;
        private readonly CancellationTokenSource _cancellationToken;
        private bool _disposed;

        /// <summary>
        /// Creates a new instance of <see cref="AppConfigurationProvider"/>.
        /// </summary>
        /// <param name="client">The <see cref="ConfigurationClient"/> to use for retrieving values.</param>
        /// <param name="options">The <see cref="AppConfigurationOptions"/> to configure provider behaviors.</param>
        /// <exception cref="ArgumentNullException">When either <paramref name="client"/> or <see cref="AppConfigurationOptions.Manager"/> is <code>null</code>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <see cref="AppConfigurationOptions.ReloadInterval"/> is not positive or <code>null</code>.</exception>
        public AppConfigurationProvider(ConfigurationClient client, AppConfigurationOptions options = null)
        {
            options ??= new AppConfigurationOptions();
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
            _selector = options.Selector ?? new SettingSelector();
        }

        /// <summary>
        /// Load settings into this provider.
        /// </summary>
        public override void Load()
        {
            var settingPages = _client.GetConfigurationSettings(_selector);
            var newLoadedSettings = new Dictionary<string, ConfigurationSetting>(StringComparer.OrdinalIgnoreCase);
            var oldLoadedSettings = Interlocked.Exchange(ref _loadedSettings, null);

            foreach (var setting in settingPages)
            {
                if (!_manager.Load(setting))
                {
                    continue;
                }

                var settingKey = setting.Key;
                if (oldLoadedSettings != null && oldLoadedSettings.TryGetValue(settingKey, out var existingSetting) && IsUpToDate(existingSetting, setting))
                {
                    oldLoadedSettings.Remove(settingKey);
                    newLoadedSettings[settingKey] = existingSetting;
                }
                else
                {
                    newLoadedSettings[settingKey] = setting;
                }
            }

            _loadedSettings = newLoadedSettings;

            bool hasChanges = oldLoadedSettings == null
                || newLoadedSettings.Count != (oldLoadedSettings.Count + newLoadedSettings.Count - oldLoadedSettings.Count)
                || oldLoadedSettings.Any();

            if (hasChanges)
            {
                Data = _manager.GetData(newLoadedSettings.Values);
                if (oldLoadedSettings != null)
                {
                    OnReload();
                }
            }

            // schedule a polling task only if none exists and a valid delay is specified
            if (_pollingTask == null && _reloadInterval != null)
            {
                _pollingTask = PollForSettingChangesAsync();
            }
        }

        private async Task PollForSettingChangesAsync()
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
            var newLoadedSettings = new Dictionary<string, ConfigurationSetting>(StringComparer.OrdinalIgnoreCase);
            var oldLoadedSettings = Interlocked.Exchange(ref _loadedSettings, null);

            await foreach (var setting in _client.GetConfigurationSettingsAsync(_selector).ConfigureAwait(false))
            {
                if (!_manager.Load(setting))
                {
                    continue;
                }

                var settingKey = setting.Key;
                if (oldLoadedSettings != null && oldLoadedSettings.TryGetValue(settingKey, out var existingSetting) && IsUpToDate(existingSetting, setting))
                {
                    oldLoadedSettings.Remove(settingKey);
                    newLoadedSettings[settingKey] = existingSetting;
                }
                else
                {
                    newLoadedSettings[settingKey] = setting;
                }
            }

            _loadedSettings = newLoadedSettings;

            bool hasChanges = oldLoadedSettings == null
                || newLoadedSettings.Count != (oldLoadedSettings.Count + newLoadedSettings.Count - oldLoadedSettings.Count)
                || oldLoadedSettings.Any();

            if (hasChanges)
            {
                Data = _manager.GetData(newLoadedSettings.Values);
                if (oldLoadedSettings != null)
                {
                    OnReload();
                }
            }
        }

        /// <summary>
        /// Frees resources held by the <see cref="AppConfigurationProvider"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Frees resources held by the <see cref="AppConfigurationProvider"/> object.
        /// </summary>
        /// <param name="disposing">true if called from <see cref="Dispose()"/>, otherwise false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    _cancellationToken.Cancel();
                    _cancellationToken.Dispose();
                }

                _disposed = true;
            }
        }

        private static bool IsUpToDate(ConfigurationSetting current, ConfigurationSetting updated)
        {
            if (updated.ETag != default && current.ETag != default)
            {
                return updated.ETag == current.ETag;
            }

            return false;
        }
    }
}
