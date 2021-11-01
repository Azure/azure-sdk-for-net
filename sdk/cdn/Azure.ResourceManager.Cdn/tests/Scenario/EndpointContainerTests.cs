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
    public class EndpointContainerTests : CdnManagementTestBase
    {
        public EndpointContainerTests(bool isAsync)
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
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            Assert.AreEqual(endpointName, endpoint.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await profile.GetEndpoints().CreateOrUpdateAsync(null, endpoint.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, null));
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
            _ = await CreateEndpoint(profile, endpointName);
            int count = 0;
            await foreach (var tempEndpoint in profile.GetEndpoints().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
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
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            Endpoint getEndpoint = await profile.GetEndpoints().GetAsync(endpointName);
            ResourceDataHelper.AssertValidEndpoint(endpoint, getEndpoint);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await profile.GetEndpoints().GetAsync(null));
        }
    }
}
