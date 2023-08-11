// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    internal class AssetsTest : EasmClientTest
    {
        private string assetName;
        private string assetKind;
        private string filter;
        private string assetId;

        public AssetsTest(bool isAsync) : base(isAsync)
        {
            assetName = "ku.edu";
            assetKind = "domain";
            filter = "name = " + assetName + " and type = " + assetKind;
            assetId = assetKind + "$$" + "kumc.edu";
        }

        [RecordedTest]
        public async Task AssetsListTest()
        {
            Response<AssetPageResult> response = await client.GetAssetResourcesAsync(filter);
            AssetResource assetResponse = response.Value.Value[0];
            Assert.AreEqual(assetName, assetResponse.Name);
            // Assert.IsNotEmpty(UUID_REGEX.Matches(assetResponse.Uuid));
        }

        [RecordedTest]
        public async Task AssetsGetTest()
        {
            Response<AssetResource> response = await client.GetAssetResourceAsync(assetId);
            AssetResource assetResponse = response.Value;
            Assert.AreEqual("kumc.edu", assetResponse.Name);
            Assert.IsNotEmpty(UUID_REGEX.Matches(assetResponse.Uuid.ToString()));
            DomainAssetResource domain = (DomainAssetResource)assetResponse;
            Assert.NotNull(domain.Asset.Count);
        }

        [RecordedTest]
        public async Task AssetsUpdateTest()
        {
            AssetUpdateData assetUpdateRequest = new AssetUpdateData();
            assetUpdateRequest.ExternalId = "new_external_id";
            Response<TaskResource> response = await client.UpdateAssetsAsync(filter, assetUpdateRequest);

            TaskResource taskResponse = response.Value;
            Assert.AreEqual(TaskState.Complete, taskResponse.State);
            Assert.AreEqual(TaskPhase.Complete, taskResponse.Phase);
            Assert.IsNotEmpty(UUID_REGEX.Matches(taskResponse.Id));
        }
    }
}
