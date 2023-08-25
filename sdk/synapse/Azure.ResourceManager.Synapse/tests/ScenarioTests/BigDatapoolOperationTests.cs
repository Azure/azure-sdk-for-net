// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Synapse.Models;
using Azure.ResourceManager.Synapse.Tests;
using System.Collections.Generic;
using NUnit;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Synapse.Tests.Helpers;
using Azure.Core.TestFramework;
using System;
using System.Linq;

namespace Azure.ResourceManager.Synapse.Tests
{
    public class BigDatapoolOperationTests : SynapseManagementTestBase
    {
        public BigDatapoolOperationTests(bool async) : base(async)
        { }

        [SetUp]
        public async Task Initialize()
        {
            await TestInitialize();

            await CreateWorkspace();
        }

        [Test]
        [RecordedTest]
        public async Task TestBigDatapoolLifeCycle()
        {
            var workspaceName = WorkspaceResource.Data.Name;

            // create BigDatapool unable autoscale
            string bigDatapoolName = Recording.GenerateAssetName("BigDatapool");
            var createBigDatapoolParams = CommonData.PrepareBigDatapoolCreateParams(enableAutoScale:false, enableAutoPause:false);
            SynapseBigDataPoolInfoCollection bigdatapoolCollection = WorkspaceResource.GetSynapseBigDataPoolInfos();
            var bigDatapoolUnableAutoScale = (await bigdatapoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, bigDatapoolName, createBigDatapoolParams)).Value;
            Assert.AreEqual(CommonTestFixture.SparkpoolType, bigDatapoolUnableAutoScale.Data.ResourceType);
            Assert.AreEqual(bigDatapoolName, bigDatapoolUnableAutoScale.Data.Name);
            Assert.AreEqual(CommonData.Location, bigDatapoolUnableAutoScale.Data.Location);

            // update BigDatapool
            var bigDatapoolCreated = (await bigdatapoolCollection.GetAsync(bigDatapoolName)).Value;
            Dictionary<string, string> tagsToUpdate = new Dictionary<string, string> { { "TestTag", "TestUpdate" } };
            SynapseBigDataPoolInfoPatch bigdataPoolPatchInfo = new SynapseBigDataPoolInfoPatch { };
            bigdataPoolPatchInfo.Tags.ReplaceWith(tagsToUpdate);
            await bigDatapoolCreated.UpdateAsync(bigdataPoolPatchInfo);

            var bigDatapoolUpdate = (await bigdatapoolCollection.GetAsync(bigDatapoolName)).Value;
            Assert.NotNull(bigDatapoolUpdate.Data.Tags);
            Assert.AreEqual("TestUpdate", bigDatapoolUpdate.Data.Tags["TestTag"]);

            // Enable Auto-scale and Auto-pause
            createBigDatapoolParams = CommonData.PrepareBigDatapoolCreateParams(enableAutoScale: true, enableAutoPause: true);
            var bigDatapoolEnableAutoScale = (await bigdatapoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, bigDatapoolName, createBigDatapoolParams)).Value;
            Assert.AreEqual(CommonTestFixture.SparkpoolType, bigDatapoolUnableAutoScale.Data.ResourceType);
            Assert.AreEqual(bigDatapoolName, bigDatapoolUnableAutoScale.Data.Name);
            Assert.AreEqual(CommonData.Location, bigDatapoolUnableAutoScale.Data.Location);
            Assert.True(bigDatapoolEnableAutoScale.Data.AutoScale.IsEnabled);
            Assert.AreEqual(CommonData.AutoScaleMaxNodeCount, bigDatapoolEnableAutoScale.Data.AutoScale.MaxNodeCount);
            Assert.AreEqual(CommonData.AutoScaleMinNodeCount, bigDatapoolEnableAutoScale.Data.AutoScale.MinNodeCount);
            Assert.True(bigDatapoolEnableAutoScale.Data.AutoPause.IsEnabled);
            Assert.AreEqual(CommonData.AutoPauseDelayInMinute, bigDatapoolEnableAutoScale.Data.AutoPause.DelayInMinutes);

            // list BigDatapool from workspace
            var bigDataPoolFromWorkspace = bigdatapoolCollection.GetAllAsync();
            var bigDataPoolList = await bigDataPoolFromWorkspace.ToEnumerableAsync();
            var bigDatapoolCount = bigDataPoolList.Count;
            var bigDataPool = bigDataPoolList.Single(bigdatapool => bigdatapool.Data.Name == bigDatapoolName);

            Assert.True(bigDataPool != null, string.Format("BigDatapool created earlier is not found when listing all in workspace {0}", workspaceName));

            // delete spark pool
            await bigDataPool.DeleteAsync(WaitUntil.Completed);
            var bigDatapoolAfterDelete = await bigdatapoolCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(bigDatapoolCount - 1, bigDatapoolAfterDelete.Count);
        }
    }
}
