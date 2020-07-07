// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Loggers
{
    internal class CompositeFunctionEventCollector : IAsyncCollector<FunctionInstanceLogEntry>
    {
        private IEnumerable<IAsyncCollector<FunctionInstanceLogEntry>> _collectors;

        public CompositeFunctionEventCollector(params IAsyncCollector<FunctionInstanceLogEntry>[] collectors)
        {
            _collectors = collectors;
        }

        public async Task AddAsync(FunctionInstanceLogEntry item, CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (IAsyncCollector<FunctionInstanceLogEntry> collector in _collectors)
            {
                await collector.AddAsync(item, cancellationToken);
            }
        }

        public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (IAsyncCollector<FunctionInstanceLogEntry> collector in _collectors)
            {
                await collector.FlushAsync(cancellationToken);
            }
        }
    }
}
