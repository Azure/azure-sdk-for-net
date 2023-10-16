// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal class CleanupService : IHostedService
    {
        private readonly MessagingProvider _provider;

        public CleanupService(MessagingProvider provider)
        {
            _provider = provider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _provider.DisposeAsync().ConfigureAwait(false);
        }
    }
}