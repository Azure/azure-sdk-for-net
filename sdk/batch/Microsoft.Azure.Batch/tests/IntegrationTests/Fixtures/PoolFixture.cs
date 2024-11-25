// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using IntegrationTestUtilities;

    public abstract class PoolFixture : IDisposable
    {
        public const string OSFamily = "4";
        public const string VMSize = "Standard_D2s_v3";
        public const string AdminUserAccountName = "BatchTestAdmin";
        public const string NonAdminUserAccountName = "BatchTestNonAdmin";

        public CloudPool Pool { get; protected set; }

        public string PoolId { get; private set; }

        protected readonly BatchClient client;

        protected PoolFixture(string poolId)
        {
            PoolId = poolId;
            client = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
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
            client.Dispose();
        }

        protected CloudPool FindPoolIfExists()
        {
            // reuse existing pool if it exists
            List<CloudPool> pools = new List<CloudPool>(client.PoolOperations.ListPools());

            foreach (CloudPool curPool in pools)
            {
                if (curPool.Id.Equals(PoolId))
                {
                    return curPool;
                }
            }

            return null;
        }

        public static CloudPool WaitForPoolAllocation(BatchClient client, string poolId)
        {
            CloudPool thePool = client.PoolOperations.GetPool(poolId);

            //Wait for pool to be in a usable state
            //TODO: Use a Utilities waiter
            TimeSpan computeNodeAllocationTimeout = TimeSpan.FromMinutes(10);
            TestUtilities.WaitForPoolToReachStateAsync(client, poolId, AllocationState.Steady, computeNodeAllocationTimeout).Wait();

            //Wait for the compute nodes in the pool to be in a usable state
            //TODO: Use a Utilities waiter
            TimeSpan computeNodeSteadyTimeout = TimeSpan.FromMinutes(25);
            DateTime allocationWaitStartTime = DateTime.UtcNow;
            DateTime timeoutAfterThisTimeUtc = allocationWaitStartTime.Add(computeNodeSteadyTimeout);

            IEnumerable<ComputeNode> computeNodes = thePool.ListComputeNodes();

            while (computeNodes.Any(computeNode => computeNode.State != ComputeNodeState.Idle))
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                computeNodes = thePool.ListComputeNodes().ToList();
                if (DateTime.UtcNow > timeoutAfterThisTimeUtc)
                {
                    throw new Exception("CreatePool: Timed out waiting for compute nodes in pool to reach idle state.  Timeout: " + computeNodeSteadyTimeout.ToString());
                }
            }

            return thePool;
        }
    }

}
