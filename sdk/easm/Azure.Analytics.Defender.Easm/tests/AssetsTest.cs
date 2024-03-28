// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    internal class AssetsTest : EasmClientTest
    {
        private string assetName;
        private string assetType;
        private string assetId;
        private string filter;

        public AssetsTest(bool isAsync) : base(isAsync)
        {
            assetName = "ku.edu";
            assetType = "domain";
            filter = "name = " + assetName + " and type = " + assetType;
            assetId = assetType + "$$" + assetName;
        }

        [Test]
        public async System.Threading.Tasks.Task AssetsListTest()
        {
            var results = client.GetAssetResourcesAsync();
            Assert.IsNotNull(results);
            await foreach (var result in results)
            {
                Assert.IsNotNull((result.Name));
                break;
            }
        }

        [Test]
        public async System.Threading.Tasks.Task AssetsGetTest()
        {
            var result = await client.GetAssetResourceAsync(assetId);
            AssetResource resource = result.Value;
            Assert.AreEqual(assetName, resource.Name);
        }

        [Test]
        public async System.Threading.Tasks.Task AssetUpdateTest()
        {
            AssetUpdatePayload assetUpdateData = new AssetUpdatePayload();
            assetUpdateData.ExternalId = "EXT040";

            Response<TaskResource> result = await client.UpdateAssetsAsync(filter, assetUpdateData);
            TaskResource task = result.Value;
            Assert.AreEqual(TaskResourceState.Complete, task.State);
            Assert.AreEqual(TaskResourcePhase.Complete, task.Phase);
            Assert.IsNotEmpty(UUID_REGEX.Matches(task.Id));
        }
    }
}
