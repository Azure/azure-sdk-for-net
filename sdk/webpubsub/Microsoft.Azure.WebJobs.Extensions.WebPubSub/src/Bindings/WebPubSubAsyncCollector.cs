﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubAsyncCollector : IAsyncCollector<WebPubSubOperation>
    {
        private readonly IWebPubSubService _service;

        internal WebPubSubAsyncCollector(IWebPubSubService service)
        {
            _service = service;
        }

        public async Task AddAsync(WebPubSubOperation item, CancellationToken cancellationToken = default)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            try
            {
                var method = typeof(IWebPubSubService).GetMethod(item.OperationKind.ToString(),
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                var task = (Task)method.Invoke(_service, new object[] { item });

                await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Not supported operation: {item.OperationKind}, exception: {ex}");
            }
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
