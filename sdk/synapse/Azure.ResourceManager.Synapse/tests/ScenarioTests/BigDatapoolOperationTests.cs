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
            Assert.That(bigDatapoolUnableAutoScale.Data.ResourceType, Is.EqualTo(CommonTestFixture.SparkpoolType));
            Assert.That(bigDatapoolUnableAutoScale.Data.Name, Is.EqualTo(bigDatapoolName));
            Assert.That(bigDatapoolUnableAutoScale.Data.Location, Is.EqualTo(CommonData.Location));

            // update BigDatapool
            var bigDatapoolCreated = (await bigdatapoolCollection.GetAsync(bigDatapoolName)).Value;
            Dictionary<string, string> tagsToUpdate = new Dictionary<string, string> { { "TestTag", "TestUpdate" } };
            SynapseBigDataPoolInfoPatch bigdataPoolPatchInfo = new SynapseBigDataPoolInfoPatch { };
            bigdataPoolPatchInfo.Tags.ReplaceWith(tagsToUpdate);
            await bigDatapoolCreated.UpdateAsync(bigdataPoolPatchInfo);

            var bigDatapoolUpdate = (await bigdatapoolCollection.GetAsync(bigDatapoolName)).Value;
            Assert.That(bigDatapoolUpdate.Data.Tags, Is.Not.Null);
            Assert.That(bigDatapoolUpdate.Data.Tags["TestTag"], Is.EqualTo("TestUpdate"));

            // Enable Auto-scale and Auto-pause
            createBigDatapoolParams = CommonData.PrepareBigDatapoolCreateParams(enableAutoScale: true, enableAutoPause: true);
            var bigDatapoolEnableAutoScale = (await bigdatapoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, bigDatapoolName, createBigDatapoolParams)).Value;
            Assert.That(bigDatapoolUnableAutoScale.Data.ResourceType, Is.EqualTo(CommonTestFixture.SparkpoolType));
            Assert.That(bigDatapoolUnableAutoScale.Data.Name, Is.EqualTo(bigDatapoolName));
            Assert.That(bigDatapoolUnableAutoScale.Data.Location, Is.EqualTo(CommonData.Location));
            Assert.That(bigDatapoolEnableAutoScale.Data.AutoScale.IsEnabled, Is.True);
            Assert.That(bigDatapoolEnableAutoScale.Data.AutoScale.MaxNodeCount, Is.EqualTo(CommonData.AutoScaleMaxNodeCount));
            Assert.That(bigDatapoolEnableAutoScale.Data.AutoScale.MinNodeCount, Is.EqualTo(CommonData.AutoScaleMinNodeCount));
            Assert.That(bigDatapoolEnableAutoScale.Data.AutoPause.IsEnabled, Is.True);
            Assert.That(bigDatapoolEnableAutoScale.Data.AutoPause.DelayInMinutes, Is.EqualTo(CommonData.AutoPauseDelayInMinute));

            // list BigDatapool from workspace
            var bigDataPoolFromWorkspace = bigdatapoolCollection.GetAllAsync();
            var bigDataPoolList = await bigDataPoolFromWorkspace.ToEnumerableAsync();
            var bigDatapoolCount = bigDataPoolList.Count;
            var bigDataPool = bigDataPoolList.Single(bigdatapool => bigdatapool.Data.Name == bigDatapoolName);

            Assert.That(bigDataPool != null, Is.True, string.Format("BigDatapool created earlier is not found when listing all in workspace {0}", workspaceName));

            // delete spark pool
            await bigDataPool.DeleteAsync(WaitUntil.Completed);
            var bigDatapoolAfterDelete = await bigdatapoolCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(bigDatapoolAfterDelete.Count, Is.EqualTo(bigDatapoolCount - 1));
        }
    }
}
