// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class OriginContainerTests : CdnManagementTestBase
    {
        public OriginContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpointWithOriginGroup(profile, endpointName);
            string originName = Recording.GenerateAssetName("origin-");
            Origin origin = await CreateOrigin(endpoint, originName);
            Assert.AreEqual(originName, origin.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOrigins().CreateOrUpdateAsync(null, origin.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOrigins().CreateOrUpdateAsync(originName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpointWithOriginGroup(profile, endpointName);
            string originName = Recording.GenerateAssetName("origin-");
            _ = await CreateOrigin(endpoint, originName);
            int count = 0;
            await foreach (var tempOrigin in endpoint.GetOrigins().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpointWithOriginGroup(profile, endpointName);
            string originName = Recording.GenerateAssetName("origin-");
            Origin origin = await CreateOrigin(endpoint, originName);
            Origin getOrigin = await endpoint.GetOrigins().GetAsync(originName);
            ResourceDataHelper.AssertValidOrigin(origin, getOrigin);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOrigins().GetAsync(null));
        }
    }
}
