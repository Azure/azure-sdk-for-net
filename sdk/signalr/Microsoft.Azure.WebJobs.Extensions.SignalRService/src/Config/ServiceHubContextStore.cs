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
        private readonly ConcurrentDictionary<string, (Lazy<Task<IServiceHubContext>> Lazy, IServiceHubContext Value)> store = new(StringComparer.OrdinalIgnoreCase);
        private readonly IServiceEndpointManager endpointManager;

        public IServiceManager ServiceManager { get; }

        public AccessKey[] AccessKeys => endpointManager.Endpoints.Keys.Select(endpoint => endpoint.AccessKey).ToArray();

        public ServiceHubContextStore(IServiceEndpointManager endpointManager, IServiceManager serviceManager)
        {
            this.endpointManager = endpointManager;
            ServiceManager = serviceManager;
        }

        public ValueTask<IServiceHubContext> GetAsync(string hubName)
        {
            var pair = store.GetOrAdd(hubName,
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
                store.TryUpdate(hubName, (null, value), pair);
                return value;
            }
            catch (Exception)
            {
                store.TryRemove(hubName, out _);
                throw;
            }
        }
    }
}