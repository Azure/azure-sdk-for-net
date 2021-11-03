// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class ServiceHubContextStore : IInternalServiceHubContextStore
    {
        private readonly ConcurrentDictionary<string, (Lazy<Task<IServiceHubContext>> Lazy, IServiceHubContext Value)> _store = new(StringComparer.OrdinalIgnoreCase);
        private readonly IServiceEndpointManager _endpointManager;

        public IServiceManager ServiceManager { get; }

        public AccessKey[] AccessKeys => _endpointManager.Endpoints.Keys.Select(endpoint => endpoint.AccessKey).ToArray();

        public ServiceHubContextStore(IServiceEndpointManager endpointManager, IServiceManager serviceManager)
        {
            _endpointManager = endpointManager;
            ServiceManager = serviceManager;
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
                _store.TryRemove(hubName, out _);
                throw;
            }
        }
    }
}