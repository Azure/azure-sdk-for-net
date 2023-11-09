// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    public class PoolFixture
    {
        public const string OSFamily = "4";
        public const string VMSize = "STANDARD_D1_v2";
        public const string AdminUserAccountName = "BatchTestAdmin";
        public const string NonAdminUserAccountName = "BatchTestNonAdmin";

        public BatchPool Pool { get; protected set; }

        public string PoolId { get; private set; }

        protected readonly BatchClient client;

        protected PoolFixture(string poolId, BatchClient batchClient)
        {
            PoolId = poolId;
            client = batchClient;
        }

        public void Dispose()
        {
            //This should not throw so swallow exceptions?
            try
            {
                //TODO: Turn this on?
                //this.client.PoolOperations.DeletePool(this.PoolId);
            }
            catch (Exception)
            {
            }
        }

        public async Task<BatchPool> FindPoolIfExistsAsync()
        {
            // reuse existing pool if it exists
            client.GetPoolsAsync(maxresults: 100, timeOut: 10);
            AsyncPageable<BatchPool> batchPools = client.GetPoolsAsync();

            await foreach (BatchPool curPool in batchPools)
            {
                if (curPool.Id.Equals(PoolId))
                {
                    return curPool;
                }
            }

            return null;
        }

        public static async Task<BatchPool> WaitForPoolAllocation(BatchClient client, string poolId)
        {
            BatchPool thePool = await client.GetPoolAsync(poolId);

            //Wait for pool to be in a usable state
            //TODO: Use a Utilities waiter
            TimeSpan computeNodeAllocationTimeout = TimeSpan.FromMinutes(10);
            TestUtilities.WaitForPoolToReachStateAsync(client, poolId, AllocationState.Steady, computeNodeAllocationTimeout).Wait();

            //Wait for the compute nodes in the pool to be in a usable state
            //TODO: Use a Utilities waiter
            TimeSpan computeNodeSteadyTimeout = TimeSpan.FromMinutes(25);
            DateTime allocationWaitStartTime = DateTime.UtcNow;
            DateTime timeoutAfterThisTimeUtc = allocationWaitStartTime.Add(computeNodeSteadyTimeout);

            List<BatchNode> computeNodes=  await client.GetNodesAsync(poolId).ToEnumerableAsync();

            while (computeNodes.Any(computeNode => computeNode.State != BatchNodeState.Idle))
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                computeNodes = await client.GetNodesAsync(poolId).ToEnumerableAsync();
                if (DateTime.UtcNow > timeoutAfterThisTimeUtc)
                {
                    throw new Exception("CreatePool: Timed out waiting for compute nodes in pool to reach idle state.  Timeout: " + computeNodeSteadyTimeout.ToString());
                }
            }

            return thePool;
        }
    }
}
