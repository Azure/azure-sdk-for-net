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
    public class BatchNodeIntegrationTests : BatchLiveTestBase
    {
        /// <summary>BatchNodeIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchNodeIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchNodeIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchNodeIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListBatchNode()
        {
            var client = CreateBatchClient();
            IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client, "ListBatchNode", isPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(2);

                int count = 0;
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    count++;
                }

                // verify we found at least one poolnode
                Assert.AreEqual(2, count);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
