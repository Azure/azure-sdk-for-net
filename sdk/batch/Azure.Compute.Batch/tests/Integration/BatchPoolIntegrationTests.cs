// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.Integration
{
    public class BatchPoolIntegrationTests : BatchLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchPoolIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchPoolIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchPoolIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchPoolIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetPoolNodeCounts()
        {
            var client = CreateBatchClient();
            IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client);

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync();

                int count = 0;
                bool poolFound = false;
                await foreach (BatchPoolNodeCounts item in client.GetPoolNodeCountsAsync())
                {
                    count++;
                    poolFound |= pool.Id.Equals(item.PoolId, StringComparison.OrdinalIgnoreCase);
                }

                // verify we found at least one poolnode
                Assert.AreNotEqual(0, count);
                Assert.IsTrue(poolFound);
            }
            finally
            {
                iaasWindowsPoolFixture.Dispose();
            }
        }

        [RecordedTest]
        public async Task PoolExists()
        {
            var client = CreateBatchClient();
            IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client);

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                var poolExist = await client.PoolExistsAsync(pool.Id);
                var poolDoesntExist = await client.PoolExistsAsync("fakepool");

                // verify exists
                Assert.True(poolExist);
                Assert.False(poolDoesntExist);
            }
            finally
            {
                iaasWindowsPoolFixture.Dispose();
            }
        }

        [Ignore("Work in progress")]
        [RecordedTest]
        public async Task AutoScale()
        {
            var client = CreateBatchClient();
            IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client);

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync();

                int count = 0;
                bool poolFound = false;
                await foreach (BatchPoolNodeCounts item in client.GetPoolNodeCountsAsync())
                {
                    count++;
                    poolFound |= pool.Id.Equals(item.PoolId, StringComparison.OrdinalIgnoreCase);
                }

                // verify we found at least one poolnode
                Assert.AreNotEqual(0, count);
                Assert.IsTrue(poolFound);
            }
            finally
            {
                iaasWindowsPoolFixture.Dispose();
            }
        }

        [Ignore("Work in progress")]
        [RecordedTest]
        public async Task DeletePool()
        {
            var client = CreateBatchClient();
            string poolId = TestUtilities.GenerateResourceId();
            await client.GetJobAsync(jobId: "test");
        }

        [Ignore("Work in progress")]
        [RecordedTest]
        public async Task CreatePool_WithBlobFuseMountConfiguration()
        {
            var client = CreateBatchClient();
            string poolId = TestUtilities.GenerateResourceId();
            await client.GetJobAsync(jobId:"test");
        }
    }
}
