// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CdnOriginOperationsTests : CdnManagementTestBase
    {
        public CdnOriginOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
            string cdnOriginName = Recording.GenerateAssetName("origin-");
            CdnOriginResource cdnOrigin = await CreateCdnOrigin(cdnEndpoint, cdnOriginName);
            await cdnOrigin.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnOrigin.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
            string cdnOriginName = Recording.GenerateAssetName("origin-");
            CdnOriginResource cdnOrigin = await CreateCdnOrigin(cdnEndpoint, cdnOriginName);
            CdnOriginPatch updateOptions = new CdnOriginPatch()
            {
                HttpPort = 81,
                HttpsPort = 442,
                Priority = 1,
                Weight = 150
            };
            var lro = await cdnOrigin.UpdateAsync(WaitUntil.Completed, updateOptions);
            CdnOriginResource updatedCdnOrigin = lro.Value;
            ResourceDataHelper.AssertOriginUpdate(updatedCdnOrigin, updateOptions);
        }
    }
}
