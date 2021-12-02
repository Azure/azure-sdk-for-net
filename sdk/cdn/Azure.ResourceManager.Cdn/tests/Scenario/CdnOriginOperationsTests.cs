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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
            string cdnOriginName = Recording.GenerateAssetName("origin-");
            CdnOrigin cdnOrigin = await CreateCdnOrigin(cdnEndpoint, cdnOriginName);
            await cdnOrigin.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnOrigin.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpointWithOriginGroup(cdnProfile, cdnEndpointName);
            string cdnOriginName = Recording.GenerateAssetName("origin-");
            CdnOrigin cdnOrigin = await CreateCdnOrigin(cdnEndpoint, cdnOriginName);
            OriginUpdateOptions updateOptions = new OriginUpdateOptions()
            {
                HttpPort = 81,
                HttpsPort = 442,
                Priority = 1,
                Weight = 150
            };
            var lro = await cdnOrigin.UpdateAsync(updateOptions);
            CdnOrigin updatedCdnOrigin = lro.Value;
            ResourceDataHelper.AssertOriginUpdate(updatedCdnOrigin, updateOptions);
        }
    }
}
