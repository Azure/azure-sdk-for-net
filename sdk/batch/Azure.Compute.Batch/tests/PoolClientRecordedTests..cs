// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using BatchService;
using BatchService.Models;
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
            Pool poolClient = serviceClient.GetPoolClient();
            string poolId = GetId("Pool");

            try
            {
                BatchPool pool = CreatePool(poolId, poolId);

                await poolClient.AddAsync(pool);

                Response response = await poolClient.ExistsAsync(poolId);
                Assert.True(response.Status == 200);
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
            Pool poolClient = serviceClient.GetPoolClient();

            string poolId = GetId("NoPool");
            Response response = await poolClient.ExistsAsync(poolId);
            Assert.True(response.Status == 404);
        }

        private BatchPool CreatePool(string poolId, string poolDisplayName)
        {
            ImageReference image = new ImageReference
            {
                Publisher = "windowsserver",
                Offer = "microsoftwindowsserver",
                Sku = "datacenter-core-20h2-with-containers-smalldisk-gs"
            };

            VirtualMachineConfiguration config = new VirtualMachineConfiguration(image, "batch.node.windows amd64");
            BatchPool pool = new BatchPool
            {
                Id = poolId,
                DisplayName = poolDisplayName,
                VirtualMachineConfiguration = config,
                VmSize = "standard_ds1_v2",
                TargetDedicatedNodes = 2
            };

            return pool;
        }
    }
}
