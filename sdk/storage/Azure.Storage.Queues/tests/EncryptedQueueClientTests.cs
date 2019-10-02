// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Queues.Tests;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    public class EncryptedQueueClientTests : QueueTestBase
    {
        public EncryptedQueueClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        // Placeholder test to verify things work end-to-end
        [Test]
        public async Task DeleteAsync()
        {
            // Create an encrypted queue
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));
            await queue.CreateAsync();

            // Delete the queue
            var result = await queue.DeleteAsync();
            Assert.AreNotEqual(default, result.Headers.RequestId, $"{nameof(result)} may not be populated");
        }
    }
}
