// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal sealed class ServiceHubContextStore : IInternalServiceHubContextStore
    {
        private readonly ConcurrentDictionary<string, (Lazy<Task<IServiceHubContext>> Lazy, IServiceHubContext Value)> _store = new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, Lazy<Task<object>>> _stronglyTypedStore = new(StringComparer.OrdinalIgnoreCase);
        private readonly ServiceManager _serviceManager;

        public IServiceManager ServiceManager => _serviceManager as IServiceManager;

        public IOptionsMonitor<SignatureValidationOptions> SignatureValidationOptions { get; }

        public ServiceHubContextStore(IOptionsMonitor<SignatureValidationOptions> signatureValidationOptions, ServiceManager serviceManager)
        {
            SignatureValidationOptions = signatureValidationOptions;
            _serviceManager = serviceManager;
        }

        public async ValueTask<ServiceHubContext<T>> GetAsync<T>(string hubName) where T : class
        {
            // The GetAsync for strongly typed hub is more simple than that for weak typed hub, as it removes codes to handle transient errors. The creation of service hub context should not contain transient errors.
            var lazy = _stronglyTypedStore.GetOrAdd(hubName, new Lazy<Task<object>>(async () => await _serviceManager.CreateHubContextAsync<T>(hubName, default).ConfigureAwait(false)));
            var hubContext = await lazy.Value.ConfigureAwait(false);
            return (ServiceHubContext<T>)hubContext;
        }

        public ValueTask<IServiceHubContext> GetAsync(string hubName)
        {
            var pair = _store.GetOrAdd(hubName,
                (new Lazy<Task<IServiceHubContext>>(
                    () => ServiceManager.CreateHubContextAsync(hubName)), default));
            return GetAsyncCore(hubName, pair);
        }

        private ValueTask<IServiceHubContext> GetAsyncCore(string hubName, (Lazy<Task<IServiceHubContext>> Lazy, IServiceHubContext Value) pair)
        {
            if (pair.Lazy == null)
            {
                return new ValueTask<IServiceHubContext>(pair.Value);
            }
            else
            {
                return new ValueTask<IServiceHubContext>(GetFromLazyAsync(hubName, pair));
            }
        }

        private async Task<IServiceHubContext> GetFromLazyAsync(string hubName, (Lazy<Task<IServiceHubContext>> Lazy, IServiceHubContext Value) pair)
        {
            try
            {
                var value = await pair.Lazy.Value.ConfigureAwait(false);
                _store.TryUpdate(hubName, (null, value), pair);
                return value;
            }
            catch (Exception)
            {
                // Allow to retry for transient errors.
                _store.TryRemove(hubName, out _);
                throw;
            }
        }

        public async ValueTask DisposeAsync()
        {
            _serviceManager.Dispose();
            foreach (var tuple in _store.Values)
            {
                if (tuple.Value is not null)
                {
                    await tuple.Value.DisposeAsync().ConfigureAwait(false);
                }
                if (tuple.Lazy is not null && tuple.Lazy.IsValueCreated)
                {
                    await (await tuple.Lazy.Value.ConfigureAwait(false)).DisposeAsync().ConfigureAwait(false);
                }
            }
            foreach (var lazy in _stronglyTypedStore.Values)
            {
                if (lazy.IsValueCreated)
                {
                    // The IAsyncDisposable interface doesn't apply to ServiceHubContext<T> on netstandard2.0 yet.
                    ((IDisposable)await lazy.Value.ConfigureAwait(false)).Dispose();
                }
            }
        }

        public void Dispose()
        {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            DisposeAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }
    }
}