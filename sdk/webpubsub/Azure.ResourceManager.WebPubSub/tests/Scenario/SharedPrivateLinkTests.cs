// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.WebPubSub.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.WebPubSub.Models;
using NUnit.Framework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.Core;

namespace Azure.ResourceManager.WebPubSub.Tests
{
    public class SharedPrivateLinkTests : WebPubHubServiceClientTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private WebPubSubResource _webPubSub;
        private string _webPubSubName;
        private string _linkName;
        private string _vnetName;

        private ResourceIdentifier _resourceGroupIdentifier;

        public SharedPrivateLinkTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("WebPubSubRG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _webPubSubName = SessionRecording.GenerateAssetName("WebPubSub-");
            _linkName = SessionRecording.GenerateAssetName("link-");
            _vnetName = SessionRecording.GenerateAssetName("vnet-");

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobleTearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TestTearDown()
        {
            if (await _resourceGroup.GetWebPubSubs().ExistsAsync(_webPubSubName))
            {
                var webPubSub = await _resourceGroup.GetWebPubSubs().GetAsync(_webPubSubName);
                await webPubSub.Value.DeleteAsync(WaitUntil.Completed);
            }
        }

        public async Task<WebPubSubSharedPrivateLinkResource> CreateSharedPrivateLink(string LinkName)
        {
            //1. create vnet
            var vnetData = new VirtualNetworkData()
            {
                Location = "westus2",
                Subnets =
                {
                    new SubnetData() { Name = "subnet01", AddressPrefix = "10.10.1.0/24", },
                    new SubnetData() { Name = "subnet02", AddressPrefix = "10.10.2.0/24", PrivateEndpointNetworkPolicy = "Disabled", }
                },
            };
            vnetData.AddressPrefixes.Add("10.10.0.0/16");
            var vnetContainer = _resourceGroup.GetVirtualNetworks();
            var vnet = await vnetContainer.CreateOrUpdateAsync(WaitUntil.Completed, _vnetName, vnetData);

            //TODO: 2 Create Appservice(Microsoft.Web/sites)
            string WebAppName = SessionRecording.GenerateAssetName("site-");

            //3 create SharedPrivateLink
            //TODO: Creating a SharedPrivateLink inevitably requires manual approval on the portal.
            var container = _webPubSub.GetWebPubSubSharedPrivateLinks();
            WebPubSubSharedPrivateLinkData data = new WebPubSubSharedPrivateLinkData()
            {
                PrivateLinkResourceId = new ResourceIdentifier($"{_resourceGroupIdentifier}/providers/Microsoft.Web/sites/{WebAppName}/sharedPrivateLinkResources/{LinkName}"),
                GroupId = "webPubSub",
                RequestMessage = "please approve",
            };
            var link = await container.CreateOrUpdateAsync(WaitUntil.Completed, LinkName, data);
            return link.Value;
        }

        [Test]
        [RecordedTest]
        [Ignore("Creating a SharedPrivateLink inevitably requires manual approval on the portal")]
        public async Task CreateOrUpdate()
        {
            var sharedPrivateLink = await CreateSharedPrivateLink(_linkName);
            Assert.IsNotNull(sharedPrivateLink);
            Assert.AreEqual("Approved", sharedPrivateLink.Data.Status);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            _webPubSub = await CreateDefaultWebPubSub(_webPubSubName, DefaultLocation, _resourceGroup);
            var list = await _webPubSub.GetWebPubSubSharedPrivateLinks().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
        }
    }
}
