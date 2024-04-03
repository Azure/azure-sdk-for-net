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
        /// Initializes a new instance of the <see cref="CancerProfilingClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchPoolIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancerProfilingClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchPoolIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetPoolNodeCounts()
        {
            var client = CreateBatchClient();

            // create a pool to verify we have something to query for

            //IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client);
            //BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync();

            int count = 0;
            await foreach (BatchPoolNodeCounts item in client.GetPoolNodeCountsAsync())
            {
                count++;
                var id = item.PoolId;
            }
        }

        [RecordedTest]
        public async Task CreatePool_WithBlobFuseMountConfiguration()
        {
            var client = CreateBatchClient();
            string poolId = TestUtilities.GenerateResourceId();
            await client.GetJobAsync(jobId:"test");
        }
    }
}
