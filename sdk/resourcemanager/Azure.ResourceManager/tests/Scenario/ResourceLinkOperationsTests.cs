// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class ResourceLinkOperationsTests : ResourceManagerTestBase
    {
        public ResourceLinkOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            GenericResourceData vNData = ConstructGenericVirtualNetwork();
            ResourceIdentifier vnId1 = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", Recording.GenerateAssetName("testVn-"));
            ResourceIdentifier vnId2 = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", Recording.GenerateAssetName("testVn-"));
            GenericResource vn1 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId1, vNData);
            GenericResource vn2 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId2, vNData);
            string resourceLinkName = Recording.GenerateAssetName("link-D-");
            ResourceIdentifier resourceLinkId = vnId1 + "/providers/Microsoft.Resources/links/" + resourceLinkName;
            ResourceLinkProperties properties = new ResourceLinkProperties(vnId2);
            ResourceLink resourceLink = (await vn1.GetResourceLinks().CreateOrUpdateAsync(resourceLinkId, properties)).Value;
            await resourceLink.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await resourceLink.GetAsync());
            Assert.AreEqual(404, ex.Status);
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
    }
}
