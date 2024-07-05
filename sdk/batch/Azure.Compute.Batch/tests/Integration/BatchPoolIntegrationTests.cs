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
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "GetPoolNodeCounts", IsPlayBack());
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
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "PoolExists", IsPlayBack());
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
        public async Task PoolGetPoolUsageMetrics()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "PoolGetPoolUsageMetrics", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolUsageMetrics exptedItem = null;
                await foreach (BatchPoolUsageMetrics item in client.GetPoolUsageMetricsAsync())
                {
                    exptedItem = item;
                }

                // verify that some usage exists, we can't predict what usage that might be at the time of the test
                Assert.NotNull(exptedItem);
                Assert.IsNotEmpty(exptedItem.PoolId);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task PoolRemoveNodes()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "PoolRemoveNodes", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(2);
                BatchPool orginalPool = await client.GetPoolAsync(poolID);

                string batchNodeID = "";
                int nodeCount = 0;
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    nodeCount++;
                    batchNodeID = item.Id;
                }

                Assert.AreEqual(2, nodeCount);

                BatchNodeRemoveContent content = new BatchNodeRemoveContent(new string[] { batchNodeID });
                Response response = await client.RemoveNodesAsync(poolID, content);
                Assert.AreEqual(202, response.Status);

                BatchPool modfiedPool = await client.GetPoolAsync(poolID);

                // verify that some usage exists, we can't predict what usage that might be at the time of the test
                Assert.NotNull(modfiedPool);
                Assert.AreEqual(AllocationState.Resizing, modfiedPool.AllocationState);
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
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "AutoScale", IsPlayBack());
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
                Assert.AreEqual(autoScalePool.AutoScaleFormula, poolASFormulaOrig);

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
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "ResizePool", IsPlayBack());
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

        [RecordedTest]
        public async Task ReplacePool()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "ReplacePool", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool orginalPool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                // replace pool
                BatchApplicationPackageReference[] batchApplicationPackageReferences = new BatchApplicationPackageReference[] {
                    new BatchApplicationPackageReference("dotnotsdkbatchapplication1")
                    {
                        Version = "1"
                    }
                };

                MetadataItem[] metadataIems = new MetadataItem[] {
                    new MetadataItem("name", "value")
                };

                BatchPoolReplaceContent replaceContent = new BatchPoolReplaceContent(batchApplicationPackageReferences, metadataIems);
                Response response = await client.ReplacePoolPropertiesAsync(poolID, replaceContent);
                BatchPool replacePool = await client.GetPoolAsync(poolID);
                Assert.AreEqual(replacePool.Metadata.First().Value, "value");
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task PatchPool()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "PatchPool", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool orginalPool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                // update pool
                BatchPoolUpdateContent updateContent = new BatchPoolUpdateContent();
                updateContent.Metadata.Add(new MetadataItem("name", "value"));
                updateContent.ApplicationPackageReferences.Add(new BatchApplicationPackageReference("dotnotsdkbatchapplication1")
                {
                    Version = "1"
                });

                Response response = await client.UpdatePoolAsync(poolID, updateContent);
                BatchPool patchPool = await client.GetPoolAsync(poolID);
                Assert.AreEqual(patchPool.Metadata.First().Value, "value");
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
