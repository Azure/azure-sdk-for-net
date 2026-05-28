// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Batch.FileStaging.Tests.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using IntegrationTestUtilities;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class PoolFixture : IDisposable
    {
        public const string OSFamily = "4";
        public const string VMSize = "STANDARD_D1_v2";

        public CloudPool Pool { get; protected set; }

        public string PoolId { get; private set; }

        protected readonly BatchClient client;

        protected PoolFixture(string poolId)
        {
            this.PoolId = poolId;
            this.client = TestUtilities.OpenBatchClientFromEnvironment();
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
            this.client.Dispose();
        }

        protected CloudPool FindPoolIfExists()
        {
            // reuse existing pool if it exists
            List<CloudPool> pools = new List<CloudPool>(this.client.PoolOperations.ListPools());

            foreach (CloudPool curPool in pools)
            {
                if (curPool.Id.Equals(this.PoolId))
                {
                    return curPool;
                }
            }

            return null;
        }

        protected static CloudPool WaitForPoolAllocation(BatchClient client, string poolId)
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
