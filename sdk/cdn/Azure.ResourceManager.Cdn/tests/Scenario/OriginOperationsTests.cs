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
    public class OriginOperationsTests : CdnManagementTestBase
    {
        public OriginOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpointWithOriginGroup(profile, endpointName);
            string originName = Recording.GenerateAssetName("origin-");
            Origin origin = await CreateOrigin(endpoint, originName);
            await origin.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await origin.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpointWithOriginGroup(profile, endpointName);
            string originName = Recording.GenerateAssetName("origin-");
            Origin origin = await CreateOrigin(endpoint, originName);
            OriginUpdateParameters originUpdateParameters = new OriginUpdateParameters()
            {
                HttpPort = 81,
                HttpsPort = 442,
                Priority = 1,
                Weight = 150
            };
            var lro = await origin.UpdateAsync(originUpdateParameters);
            Origin updatedOrigin = lro.Value;
            ResourceDataHelper.AssertOriginUpdate(updatedOrigin, originUpdateParameters);
        }
    }
}
