// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // Adapter class to expose a ICollector<T> on top of IAsyncCollector<T>;
    internal class SyncAsyncCollectorAdapter<T> : ICollector<T>
    {
        private readonly IAsyncCollector<T> _inner;

        public SyncAsyncCollectorAdapter(IAsyncCollector<T> inner)
        {
            _inner = inner;
        }

        public void Add(T item)
        {
            Task.Run(async () => await _inner.AddAsync(item)).GetAwaiter().GetResult();
        }
    }
}