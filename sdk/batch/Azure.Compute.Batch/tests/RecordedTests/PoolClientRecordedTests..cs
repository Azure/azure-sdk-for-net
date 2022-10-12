// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Compute.Batch;
using Azure.Compute.Batch.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Tests.SessionTests
{
    internal class PoolClientRecordedTests : BatchRecordedTestBase
    {
        public PoolClientRecordedTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task ExistsTest()
        {
            BatchServiceClient serviceClient = CreateServiceClient();
            PoolClient poolClient = serviceClient.CreatePoolClient();
            string poolId = GetId("Pool");

            try
            {
                Pool pool = CreatePool(poolId, poolId);

                await poolClient.AddAsync(pool);
                bool exists = await poolClient.ExistsAsync(poolId);

                Assert.True(exists);
            }
            finally
            {
                await poolClient.DeleteAsync(poolId);
            }
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task DoesNotExist()
        {
            BatchServiceClient serviceClient = CreateServiceClient();
            PoolClient poolClient = serviceClient.CreatePoolClient();

            string poolId = GetId("NoPool");
            bool exists = await poolClient.ExistsAsync(poolId);

            Assert.False(exists);
        }

        private Pool CreatePool(string poolId, string poolDisplayName)
        {
            ImageReference image = new ImageReference("windowsserver", "microsoftwindowsserver", "datacenter-core-20h2-with-containers-smalldisk-gs");
            VirtualMachineConfiguration config = new VirtualMachineConfiguration(image, "batch.node.windows amd64");
            Pool pool = new Pool(poolId, poolDisplayName, config, "standard_ds1_v2");
            pool.TargetDedicatedNodes = 2;
            return pool;
        }
    }
}
