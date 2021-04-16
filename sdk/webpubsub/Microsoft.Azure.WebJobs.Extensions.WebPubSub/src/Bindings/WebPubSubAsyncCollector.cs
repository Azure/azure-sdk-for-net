// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubAsyncCollector: IAsyncCollector<WebPubSubEvent>
    {
        private readonly IWebPubSubService _service;

        internal WebPubSubAsyncCollector(IWebPubSubService service)
        {
            _service = service;
        }

        public async Task AddAsync(WebPubSubEvent item, CancellationToken cancellationToken = default)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Binding Object.");
            }

            try
            {
                var method = typeof(IWebPubSubService).GetMethod(item.Operation.ToString(),
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                await (Task)method.Invoke(_service, new object[] { item });
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Not supported operation: {item.Operation}, exception: {ex}");
            }
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
