// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal class CleanupService : IAsyncDisposable
    {
        private readonly MessagingProvider _provider;

        public CleanupService(MessagingProvider provider)
        {
            _provider = provider;
        }

        public async ValueTask DisposeAsync()
        {
            await _provider.DisposeAsync().ConfigureAwait(false);
        }
    }
}