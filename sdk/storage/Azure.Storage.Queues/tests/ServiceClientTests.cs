// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Common;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    public class ServiceClientTests : QueueTestBase
    {
        public ServiceClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task GetQueuesAsync()
        {
            var service = this.GetServiceClient_SharedKey();
            using (this.GetNewQueue(out _, service: service)) // Ensure at least one queue
            {
                var queues = await service.GetQueuesAsync().ToListAsync();
                Assert.IsTrue(queues.Count >= 1);
            }
        }

        [Test]
        public async Task GetQueuesAsync_Marker()
        {
            var service = this.GetServiceClient_SharedKey();
            using (this.GetNewQueue(out var queue, service: service)) // Ensure at least one queue
            {
                var marker = default(string);
                var queues = new List<QueueItem>();
                await foreach (var page in service.GetQueuesAsync().ByPage(marker))
                {
                    queues.AddRange(page.Values);
                }

                Assert.AreNotEqual(0, queues.Count);
                Assert.AreEqual(queues.Count, queues.Select(c => c.Name).Distinct().Count());
                Assert.IsTrue(queues.Any(c => queue.Uri == this.InstrumentClient(service.GetQueueClient(c.Name)).Uri));
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetQueuesAsync_MaxResults()
        {
            var service = this.GetServiceClient_SharedKey();
            using (this.GetNewQueue(out _, service: service))
            using (this.GetNewQueue(out var queue, service: service)) // Ensure at least two queues
            {
                var page = await
                    service.GetQueuesAsync()
                    .ByPage(pageSizeHint: 1)
                    .FirstAsync();
                Assert.AreEqual(1, page.Values.Count);
            }
        }

        [Test]
        public async Task GetQueuesAsync_Prefix()
        {
            var service = this.GetServiceClient_SharedKey();
            var prefix = "aaa";
            var queueName = prefix + this.GetNewQueueName();
            var queue = (await service.CreateQueueAsync(queueName)).Value; // Ensure at least one queue
            try
            {
                var queues = service.GetQueuesAsync(new GetQueuesOptions { Prefix = prefix });
                var items = await queues.ToListAsync();

                Assert.AreNotEqual(0, items.Count());
                Assert.IsTrue(items.All(c => c.Value.Name.StartsWith(prefix)));
                Assert.IsNotNull(items.Single(c => c.Value.Name == queueName));
            }
            finally
            {
                await service.DeleteQueueAsync(queueName);
            }
        }

        [Test]
        public async Task GetQueuesAsync_Metadata()
        {
            var service = this.GetServiceClient_SharedKey();
            using (this.GetNewQueue(out var queue, service: service)) // Ensure at least one queue
            {
                var metadata = this.BuildMetadata();
                await queue.SetMetadataAsync(metadata);
                var first = await service.GetQueuesAsync(new GetQueuesOptions { IncludeMetadata = true }).FirstAsync();
                Assert.IsNotNull(first.Value.Metadata);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetQueuesAsync_Error()
        {
            var service = this.GetServiceClient_SharedKey();
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetQueuesAsync().ByPage(continuationToken: "garbage").FirstAsync(),
                e => Assert.AreEqual("OutOfRangeInput", e.ErrorCode));
        }
    }
}
