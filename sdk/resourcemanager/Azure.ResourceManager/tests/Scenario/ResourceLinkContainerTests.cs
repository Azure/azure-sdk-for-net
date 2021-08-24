// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.Tests
{
    public class ResourceLinkContainerTests : ResourceManagerTestBase
    {
        public ResourceLinkContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            GenericResourceData vNData = ConstructGenericVirtualNetwork();
            ResourceIdentifier vnId1 = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", Recording.GenerateAssetName("testVn-"));
            ResourceIdentifier vnId2 = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", Recording.GenerateAssetName("testVn-"));
            GenericResource vn1 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId1, vNData);
            GenericResource vn2 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId2, vNData);
            string resourceLinkName = Recording.GenerateAssetName("link-C-");
            ResourceIdentifier resourceLinkId = vnId1 + "/providers/Microsoft.Resources/links/" + resourceLinkName;
            ResourceLinkProperties properties = new ResourceLinkProperties(vnId2);
            ResourceLink resourceLink = (await vn1.GetResourceLinks().CreateOrUpdateAsync(resourceLinkId, properties)).Value;
            Assert.AreEqual(resourceLinkName, resourceLink.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn1.GetResourceLinks().CreateOrUpdateAsync(null));
        }
        
        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            GenericResourceData vNData = ConstructGenericVirtualNetwork();
            ResourceIdentifier vnId1 = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", Recording.GenerateAssetName("testVn-"));
            ResourceIdentifier vnId2 = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", Recording.GenerateAssetName("testVn-"));
            ResourceIdentifier vnId3 = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", Recording.GenerateAssetName("testVn-"));
            GenericResource vn1 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId1, vNData);
            GenericResource vn2 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId2, vNData);
            GenericResource vn3 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId3, vNData);
            string resourceLinkName1 = Recording.GenerateAssetName("link-L-");
            string resourceLinkName2 = Recording.GenerateAssetName("link-L-");
            ResourceIdentifier resourceLinkId1 = vnId1 + "/providers/Microsoft.Resources/links/" + resourceLinkName1;
            ResourceIdentifier resourceLinkId2 = vnId1 + "/providers/Microsoft.Resources/links/" + resourceLinkName2;
            ResourceLinkProperties properties1 = new ResourceLinkProperties(vnId2);
            ResourceLinkProperties properties2 = new ResourceLinkProperties(vnId3);
            _ = await vn1.GetResourceLinks().CreateOrUpdateAsync(resourceLinkId1, properties1);
            _ = await vn1.GetResourceLinks().CreateOrUpdateAsync(resourceLinkId2, properties2);
            int count = 0;
            await foreach (var resourceLink in vn1.GetResourceLinks().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            GenericResourceData vNData = ConstructGenericVirtualNetwork();
            ResourceIdentifier vnId1 = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", Recording.GenerateAssetName("testVn-"));
            ResourceIdentifier vnId2 = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", Recording.GenerateAssetName("testVn-"));
            GenericResource vn1 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId1, vNData);
            GenericResource vn2 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId2, vNData);
            string resourceLinkName = Recording.GenerateAssetName("link-G-");
            ResourceIdentifier resourceLinkId = vnId1 + "/providers/Microsoft.Resources/links/" + resourceLinkName;
            ResourceLinkProperties properties = new ResourceLinkProperties(vnId2);
            ResourceLink resourceLink = (await vn1.GetResourceLinks().CreateOrUpdateAsync(resourceLinkId, properties)).Value;
            ResourceLink getResourceLink = await vn1.GetResourceLinks().GetAsync(resourceLinkId);
            AssertValidResourceLink(resourceLink, getResourceLink);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn1.GetResourceLinks().GetAsync(null));
        }

        private GenericResourceData ConstructGenericVirtualNetwork()
        {
            var virtualNetwork = new GenericResourceData(Location.WestUS2)
            {
                Properties = new JsonObject()
                {
                    {"addressSpace", new JsonObject()
                        {
                            {"addressPrefixes", new List<string>(){"10.0.0.0/16" } }
                        }
                    }
                }
            };
            return virtualNetwork;
        }
        private void AssertValidResourceLink(ResourceLink model, ResourceLink getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            if(model.Data.Properties != null || getResult.Data.Properties != null)
            {
                Assert.NotNull(model.Data.Properties);
                Assert.NotNull(getResult.Data.Properties);
                Assert.AreEqual(model.Data.Properties.Notes, getResult.Data.Properties.Notes);
                Assert.AreEqual(model.Data.Properties.SourceId, getResult.Data.Properties.SourceId);
                Assert.AreEqual(model.Data.Properties.TargetId, getResult.Data.Properties.TargetId);
            }
        }
    }
}
