// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Common;
using Azure.Storage.Common.Test;
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
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var queueEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var queueSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (queueEndpoint, queueSecondaryEndpoint), (default, default), (default, default));

            QueueServiceClient client1 = InstrumentClient(new QueueServiceClient(connectionString.ToString(true), GetOptions()));

            QueueServiceClient client2 = InstrumentClient(new QueueServiceClient(connectionString.ToString(true)));

            var builder1 = new QueueUriBuilder(client1.Uri);
            var builder2 = new QueueUriBuilder(client2.Uri);
            Assert.IsEmpty(builder1.QueueName);
            Assert.AreEqual(accountName, builder1.AccountName);
            Assert.IsEmpty(builder2.QueueName);
            Assert.AreEqual(accountName, builder2.AccountName);
        }

        [Test]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var queueEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);

            QueueServiceClient service = InstrumentClient(new QueueServiceClient(queueEndpoint, credentials));
            var builder = new QueueUriBuilder(service.Uri);

            Assert.IsEmpty(builder.QueueName);
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        public async Task GetQueuesAsync()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            using (GetNewQueue(out _, service: service)) // Ensure at least one queue
            {
                IList<Response<QueueItem>> queues = await service.GetQueuesAsync().ToListAsync();
                Assert.IsTrue(queues.Count >= 1);
            }
            var accountName = new QueueUriBuilder(service.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
        }

        [Test]
        public async Task GetQueuesAsync_Marker()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            using (GetNewQueue(out QueueClient queue, service: service)) // Ensure at least one queue
            {
                var marker = default(string);
                var queues = new List<QueueItem>();
                await foreach (Page<QueueItem> page in service.GetQueuesAsync().ByPage(marker))
                {
                    queues.AddRange(page.Values);
                }

                Assert.AreNotEqual(0, queues.Count);
                Assert.AreEqual(queues.Count, queues.Select(c => c.Name).Distinct().Count());
                Assert.IsTrue(queues.Any(c => queue.Uri == InstrumentClient(service.GetQueueClient(c.Name)).Uri));
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetQueuesAsync_MaxResults()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            using (GetNewQueue(out _, service: service))
            using (GetNewQueue(out QueueClient queue, service: service)) // Ensure at least two queues
            {
                Page<QueueItem> page = await
                    service.GetQueuesAsync()
                    .ByPage(pageSizeHint: 1)
                    .FirstAsync();
                Assert.AreEqual(1, page.Values.Count);
            }
        }

        [Test]
        public async Task GetQueuesAsync_Prefix()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            var prefix = "aaa";
            var queueName = prefix + GetNewQueueName();
            QueueClient queue = (await service.CreateQueueAsync(queueName)).Value; // Ensure at least one queue
            try
            {
                AsyncCollection<QueueItem> queues = service.GetQueuesAsync(new GetQueuesOptions { Prefix = prefix });
                IList<Response<QueueItem>> items = await queues.ToListAsync();

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
            QueueServiceClient service = GetServiceClient_SharedKey();
            using (GetNewQueue(out QueueClient queue, service: service)) // Ensure at least one queue
            {
                IDictionary<string, string> metadata = BuildMetadata();
                await queue.SetMetadataAsync(metadata);
                Response<QueueItem> first = await service.GetQueuesAsync(new GetQueuesOptions { IncludeMetadata = true }).FirstAsync();
                Assert.IsNotNull(first.Value.Metadata);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task GetQueuesAsync_Error()
        {
            QueueServiceClient service = GetServiceClient_SharedKey();
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetQueuesAsync().ByPage(continuationToken: "garbage").FirstAsync(),
                e => Assert.AreEqual("OutOfRangeInput", e.ErrorCode));
        }

        #region Secondary Storage
        [Test]
        public async Task GetQueuesAsync_SecondaryStorageFirstRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(1); // one GET failure means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageFirstRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [Test]
        public async Task GetQueuesAsync_SecondaryStorageSecondRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(2); // two GET failures means the GET request should end up using the PRIMARY host
            AssertSecondaryStorageSecondRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [Test]
        public async Task GetQueuesAsync_SecondaryStorageThirdRetrySuccessful()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(3); // three GET failures means the GET request should end up using the SECONDARY host
            AssertSecondaryStorageThirdRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        [Test]
        public async Task GetQueuesAsync_SecondaryStorage404OnSecondary()
        {
            TestExceptionPolicy testExceptionPolicy = await PerformSecondaryStorageTest(3, true);  // three GET failures + 404 on SECONDARY host means the GET request should end up using the PRIMARY host
            AssertSecondaryStorage404OnSecondary(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }

        private async Task<TestExceptionPolicy> PerformSecondaryStorageTest(int numberOfReadFailuresToSimulate, bool retryOn404 = false)
        {
            QueueServiceClient service = GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, retryOn404);
            using (GetNewQueue(out _, service: service))
            {
                IList<Response<QueueItem>> queues = await EnsurePropagatedAsync(
                    async () => await service.GetQueuesAsync().ToListAsync(),
                    queues => queues.Count > 0);
                Assert.AreEqual(1, queues.Count);
                Assert.AreEqual(200, queues[0].GetRawResponse().Status);
            }
            return testExceptionPolicy;
        }
        #endregion
    }
}
