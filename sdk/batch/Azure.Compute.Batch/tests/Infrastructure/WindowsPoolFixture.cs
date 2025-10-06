// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    internal class WindowsPoolFixture : PoolFixture
    {
        public WindowsPoolFixture(BatchClient batchClient, string poolID, bool isPlayback) : base(poolID, batchClient, isPlayback) { }

        public async Task<BatchPool> CreatePoolAsync(int targetDedicatedNodes = 1)
        {
            BatchPool currentPool = await FindPoolIfExistsAsync();

            if (currentPool == null)
            {
                BatchPoolCreateOptions batchPoolCreateOptions = CreatePoolOptions(targetDedicatedNodes);
                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
            }

            return await WaitForPoolAllocation(client, PoolId);
        }

        public BatchPoolCreateOptions CreatePoolOptions(int? targetDedicatedNodes = null)
        {
            // create a new pool
            BatchVmImageReference imageReference = new BatchVmImageReference()
            {
                Publisher = "MicrosoftWindowsServer",
                Offer = "WindowsServer",
                Sku = "2019-datacenter-smalldisk",
                Version = "latest"
            };
            VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

            BatchPoolCreateOptions batchPoolCreateOptions = new BatchPoolCreateOptions(
                PoolId,
                VMSize)
            {
                VirtualMachineConfiguration = virtualMachineConfiguration,
                TargetDedicatedNodes = targetDedicatedNodes,
            };
            return batchPoolCreateOptions;
        }

        internal async void DeletePool()
        {
            try
            {
                await client.DeletePoolAsync(PoolId);
                WaitForPoolDeletion(client, PoolId);
            }
            catch (Exception ex)
            {
                int x = 0;
                x++;
                var xx = ex.Message;
            }
        }
    }
}
