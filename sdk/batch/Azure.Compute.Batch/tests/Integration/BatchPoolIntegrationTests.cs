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
            IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client, "GetPoolNodeCounts", isPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

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
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task PoolExists()
        {
            var client = CreateBatchClient();
            IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client, "PoolExists", isPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);
                bool poolExist = await client.PoolExistsAsync(poolID);

                var poolDoesntExist = await client.PoolExistsAsync("fakepool");

                // verify exists
                Assert.True(poolExist);
                Assert.False(poolDoesntExist);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task AutoScale()
        {
            var client = CreateBatchClient();
            IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client, "AutoScale", isPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;
            string poolASFormulaOrig = "$TargetDedicated = 0;";
            string poolASFormulaNew = "$TargetDedicated = 1;";
            TimeSpan evalInterval = TimeSpan.FromMinutes(6);

            try
            {
                // create a pool to verify we have something to query for
                BatchPoolCreateContent batchPoolCreateOptions = iaasWindowsPoolFixture.CreatePoolOptions();
                batchPoolCreateOptions.EnableAutoScale = true;
                batchPoolCreateOptions.AutoScaleEvaluationInterval = evalInterval;
                batchPoolCreateOptions.AutoScaleFormula = poolASFormulaOrig;
                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
                BatchPool autoScalePool = await iaasWindowsPoolFixture.WaitForPoolAllocation(client, iaasWindowsPoolFixture.PoolId);

                // verify autoscale settings
                Assert.IsTrue(autoScalePool.EnableAutoScale);
                Assert.AreEqual(autoScalePool.AutoScaleFormula,poolASFormulaOrig);

                // evaluate autoscale formula
                BatchPoolEvaluateAutoScaleContent batchPoolEvaluateAutoScaleContent = new BatchPoolEvaluateAutoScaleContent(poolASFormulaNew);
                AutoScaleRun eval = await client.EvaluatePoolAutoScaleAsync(autoScalePool.Id, batchPoolEvaluateAutoScaleContent);
                Assert.Null(eval.Error);

                // change eval interval
                TimeSpan newEvalInterval = evalInterval + TimeSpan.FromMinutes(1);
                BatchPoolEnableAutoScaleContent batchPoolEnableAutoScaleContent = new BatchPoolEnableAutoScaleContent()
                {
                    AutoScaleEvaluationInterval = newEvalInterval,
                    AutoScaleFormula = poolASFormulaNew,
                };

                // verify
                response = await client.EnablePoolAutoScaleAsync(autoScalePool.Id, batchPoolEnableAutoScaleContent);
                Assert.AreEqual(200, response.Status);
                autoScalePool = await client.GetPoolAsync((autoScalePool.Id));
                Assert.AreEqual(autoScalePool.AutoScaleEvaluationInterval, newEvalInterval);
                Assert.AreEqual(autoScalePool.AutoScaleFormula, poolASFormulaNew);

                response = await client.DisablePoolAutoScaleAsync(autoScalePool.Id);
                Assert.AreEqual(200, response.Status);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task ResizePool()
        {
            var client = CreateBatchClient();
            IaasLinuxPoolFixture iaasWindowsPoolFixture = new IaasLinuxPoolFixture(client, "ResizePool", isPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool resizePool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                // verify exists
                BatchPoolResizeContent resizeContent = new BatchPoolResizeContent()
                {
                    TargetDedicatedNodes = 1,
                    ResizeTimeout = TimeSpan.FromMinutes(10),
                };

                // resize pool
                Response response = await client.ResizePoolAsync(poolID, resizeContent);
                resizePool = await client.GetPoolAsync(poolID);
                Assert.AreEqual(AllocationState.Resizing, resizePool.AllocationState);

                // stop resizing
                response = await client.StopPoolResizeAsync(poolID);
                Assert.AreEqual(202, response.Status);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
