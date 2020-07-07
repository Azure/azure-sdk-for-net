// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host.Dispatch
{
    /// <summary>
    /// An implementation of DispatchQueueHandler that doesn't rely on Azure Storage.
    /// </summary>
    internal class InMemoryDispatchQueueHandler : IDispatchQueueHandler
    {
        private readonly IMessageHandler _messageHandler;

        internal InMemoryDispatchQueueHandler(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        // any messages enqueued will get processed in worker pool immediately
        public Task EnqueueAsync(JObject message, CancellationToken cancellationToken)
        {
            // start executing the function
            // ignore the function result, no retry or poisonQueue
            // we don't wait on this task, exceptions will be logged by functionExecutor
            _messageHandler.TryExecuteAsync(message, cancellationToken);
            return Task.CompletedTask;
        }
    }
}
