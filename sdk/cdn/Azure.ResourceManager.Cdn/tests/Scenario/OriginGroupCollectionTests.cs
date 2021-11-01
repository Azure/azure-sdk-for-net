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
    public class OriginGroupCollectionTests : CdnManagementTestBase
    {
        public OriginGroupCollectionTests(bool isAsync)
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
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            OriginGroup originGroup = await CreateOriginGroup(endpoint, originGroupName, endpoint.Data.Origins[0].Name);
            Assert.AreEqual(originGroupName, originGroup.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOriginGroups().CreateOrUpdateAsync(null, originGroup.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, null));
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
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            _ = await CreateOriginGroup(endpoint, originGroupName, endpoint.Data.Origins[0].Name);
            int count = 0;
            await foreach (var tempOriginGroup in endpoint.GetOriginGroups().GetAllAsync())
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
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            OriginGroup originGroup = await CreateOriginGroup(endpoint, originGroupName, endpoint.Data.Origins[0].Name);
            OriginGroup getOriginGroup = await endpoint.GetOriginGroups().GetAsync(originGroupName);
            ResourceDataHelper.AssertValidOriginGroup(originGroup, getOriginGroup);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetOriginGroups().GetAsync(null));
        }
    }
}
