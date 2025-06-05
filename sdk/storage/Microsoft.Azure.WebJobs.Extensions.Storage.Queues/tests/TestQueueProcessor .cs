// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Host.Queues;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Tests
{
    public class TestQueueProcessor : QueueProcessor
    {
        public bool DeleteCalled { get; private set; }
        public CancellationToken CapturedDeleteToken { get; private set; }

        public TestQueueProcessor(QueueProcessorOptions options)
            : base(options)
        {
        }

        protected override async Task DeleteMessageAsync(QueueMessage message, CancellationToken cancellationToken)
        {
            DeleteCalled = true;
            CapturedDeleteToken = cancellationToken; // store the exact token used
            await base.DeleteMessageAsync(message, cancellationToken);
        }
    }
}
