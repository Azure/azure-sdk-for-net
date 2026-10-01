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
        private CallbackRegistration[] _callbacks = Array.Empty<CallbackRegistration>();
        private int _initialized;

        private ConfigurationManager()
        {
        }

        internal static ConfigurationManager Instance => s_instance;

        internal bool IsInitialized => Volatile.Read(ref _initialized) != 0;

        internal void Initialize()
        {
            // A later change will start the OneSettings polling worker when this transition succeeds.
            Interlocked.CompareExchange(ref _initialized, 1, 0);
        }

        internal IDisposable RegisterCallback(Func<IReadOnlyDictionary<string, string>, Task> callback)
        {
            Argument.AssertNotNull(callback, nameof(callback));

            var registration = new CallbackRegistration(this, callback);
            var spin = new SpinWait();

            while (true)
            {
                CallbackRegistration[] current = Volatile.Read(ref _callbacks);
                var updated = new CallbackRegistration[current.Length + 1];
                Array.Copy(current, updated, current.Length);
                updated[current.Length] = registration;

                if (ReferenceEquals(
                    Interlocked.CompareExchange(ref _callbacks, updated, current),
                    current))
                {
                    return registration;
                }

                spin.SpinOnce();
            }
        }

        internal async Task NotifyCallbacksAsync(IReadOnlyDictionary<string, string> settings)
        {
            Argument.AssertNotNull(settings, nameof(settings));

            CallbackRegistration[] callbacks = Volatile.Read(ref _callbacks);

            // Await each callback before invoking the next callback for this notification.
            foreach (CallbackRegistration registration in callbacks)
            {
                try
                {
                    await registration.InvokeAsync(settings).ConfigureAwait(false);
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

        private void UnregisterCallback(CallbackRegistration registration)
        {
            var spin = new SpinWait();

            while (true)
            {
                CallbackRegistration[] current = Volatile.Read(ref _callbacks);
                int index = Array.IndexOf(current, registration);
                if (index < 0)
                {
                    return;
                }

                var updated = new CallbackRegistration[current.Length - 1];
                Array.Copy(current, 0, updated, 0, index);
                Array.Copy(current, index + 1, updated, index, current.Length - index - 1);

                if (ReferenceEquals(
                    Interlocked.CompareExchange(ref _callbacks, updated, current),
                    current))
                {
                    return;
                }

                spin.SpinOnce();
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

            internal Task InvokeAsync(IReadOnlyDictionary<string, string> settings)
            {
                Func<IReadOnlyDictionary<string, string>, Task>? callback = Volatile.Read(ref _callback);
                return callback?.Invoke(settings) ?? Task.CompletedTask;
            }

            public void Dispose()
            {
                if (Interlocked.Exchange(ref _callback, null) != null)
                {
                    _manager.UnregisterCallback(this);
                }
            }
        }
    }
}
