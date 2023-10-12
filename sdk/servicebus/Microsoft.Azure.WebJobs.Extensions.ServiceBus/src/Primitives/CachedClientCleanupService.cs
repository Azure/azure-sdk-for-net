// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal class CachedClientCleanupService : IHostedService
    {
        private readonly MessagingProvider _provider;

        public CachedClientCleanupService(MessagingProvider provider)
        {
            _provider = provider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            foreach (var receiver in _provider.MessageReceiverCache.Values)
            {
                await receiver.DisposeAsync().ConfigureAwait(false);
            }
            _provider.MessageReceiverCache.Clear();

            foreach (var sender in _provider.MessageSenderCache.Values)
            {
                await sender.DisposeAsync().ConfigureAwait(false);
            }
            _provider.MessageSenderCache.Clear();

            foreach (var client in _provider.ClientCache.Values)
            {
                await client.DisposeAsync().ConfigureAwait(false);
            }
            _provider.ClientCache.Clear();
            _provider.ActionsCache.Clear();
        }
    }
}