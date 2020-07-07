// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Loggers;

namespace Microsoft.Azure.WebJobs.Logging
{
    internal class EventCollectorFactory : IEventCollectorFactory
    {
        private readonly IEnumerable<IEventCollectorProvider> _providers;

        // This allows us to take all registered providers and wrap them in a composite, if necessary.
        public EventCollectorFactory(IEnumerable<IEventCollectorProvider> providers)
        {
            _providers = providers ?? throw new ArgumentNullException(nameof(providers));
        }

        public IAsyncCollector<FunctionInstanceLogEntry> Create()
        {
            var collectors = new List<IAsyncCollector<FunctionInstanceLogEntry>>();

            foreach (IEventCollectorProvider provider in _providers)
            {
                var collector = provider.Create();
                if (collector != null)
                {
                    collectors.Add(collector);
                }
            }

            // If we have no providers, return a no-op collector
            if (!collectors.Any())
            {
                return new NullFunctionEventCollector();
            }

            return new CompositeFunctionEventCollector(collectors.ToArray());
        }

        private class NullFunctionEventCollector : IAsyncCollector<FunctionInstanceLogEntry>
        {
            public Task AddAsync(FunctionInstanceLogEntry item, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.CompletedTask;
            }

            public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.CompletedTask;
            }
        }
    }
}
