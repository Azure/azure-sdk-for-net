// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Configuration
{
    internal sealed class ConfigurationManager
    {
        // OneSettings state is shared by all Azure Monitor exporters in the process.
        private static readonly ConfigurationManager s_instance = new();
        private readonly object _lock = new();
        private readonly List<Func<IReadOnlyDictionary<string, string>, Task>> _callbacks = new();
        private bool _initialized;

        private ConfigurationManager()
        {
        }

        internal static ConfigurationManager Instance => s_instance;

        internal bool IsInitialized
        {
            get
            {
                lock (_lock)
                {
                    return _initialized;
                }
            }
        }

        internal void Initialize()
        {
            lock (_lock)
            {
                if (_initialized)
                {
                    return;
                }

                // A later change will start the OneSettings polling worker here.
                _initialized = true;
            }
        }

        internal IDisposable RegisterCallback(Func<IReadOnlyDictionary<string, string>, Task> callback)
        {
            Argument.AssertNotNull(callback, nameof(callback));

            lock (_lock)
            {
                _callbacks.Add(callback);
            }

            return new CallbackRegistration(this, callback);
        }

        internal async Task NotifyCallbacksAsync(IReadOnlyDictionary<string, string> settings)
        {
            Argument.AssertNotNull(settings, nameof(settings));

            Func<IReadOnlyDictionary<string, string>, Task>[] callbacks;
            lock (_lock)
            {
                // Invoke outside the lock so callbacks can safely register or unregister.
                callbacks = _callbacks.ToArray();
            }

            // Await each callback before invoking the next callback for this notification.
            foreach (Func<IReadOnlyDictionary<string, string>, Task> callback in callbacks)
            {
                try
                {
                    await callback(settings).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.OneSettingsCallbackFailed(ex);
                }
            }
        }

        internal Task<TimeSpan> GetConfigurationAndRefreshIntervalAsync()
        {
            // A later change will poll the change and configuration endpoints here.
            return Task.FromResult(OneSettingsConstants.DefaultRefreshInterval);
        }

        private void UnregisterCallback(Func<IReadOnlyDictionary<string, string>, Task> callback)
        {
            lock (_lock)
            {
                _callbacks.Remove(callback);
            }
        }

        private sealed class CallbackRegistration : IDisposable
        {
            private readonly ConfigurationManager _manager;
            private Func<IReadOnlyDictionary<string, string>, Task>? _callback;

            internal CallbackRegistration(
                ConfigurationManager manager,
                Func<IReadOnlyDictionary<string, string>, Task> callback)
            {
                _manager = manager;
                _callback = callback;
            }

            public void Dispose()
            {
                Func<IReadOnlyDictionary<string, string>, Task>? callback =
                    Interlocked.Exchange(ref _callback, null);
                if (callback != null)
                {
                    _manager.UnregisterCallback(callback);
                }
            }
        }
    }
}
