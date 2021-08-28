#region Snippet:Managing_ResourceLinks_Namespaces
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
#endregion
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.Tests.Samples
{
    class Sample6_ManagingResourceLinks
    {
        private GenericResource vn1;
        private GenericResource vn2;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateResourceLink()
        {
            #region Snippet:Managing_ResourceLinks_CreateResourceLink
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            ResourceLinkContainer resourceLinkContainer = armClient.GetResourceLinks();

            // Suppose we have 2 existing VirtualNetwork vn1 and vn2
            ResourceIdentifier vnId1 = vn1.Id;
            ResourceIdentifier vnId2 = vn2.Id;
            string resourceLinkName = "myLink";
            ResourceIdentifier resourceLinkId = vnId1.AppendProviderResource("Microsoft.Resources", "links", resourceLinkName);
            ResourceLinkProperties properties = new ResourceLinkProperties(vnId2);
            ResourceLink resourceLink = (await armClient.GetResourceLinks().CreateOrUpdateAsync(resourceLinkId, properties)).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetAllResourceLinks()
        {
            #region Snippet:Managing_ResourceLinks_ListResourceLinks
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            ResourceLinkContainer resourceLinkContainer = armClient.GetResourceLinks();
            ResourceIdentifier vnId1 = vn1.Id;
            AsyncPageable<ResourceLink> resourceLinks = resourceLinkContainer.GetAllAsync(vnId1);
            await foreach (var link in resourceLinks)
            {
                Console.WriteLine(link.Data.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteResourceLink()
        {
            #region Snippet:Managing_ResourceLinks_DeleteResourceLink
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            ResourceLinkContainer resourceLinkContainer = armClient.GetResourceLinks();
            string resourceLinkName = "myLink";
            ResourceIdentifier vnId1 = vn1.Id;
            ResourceIdentifier resourceLinkId = vnId1.AppendProviderResource("Microsoft.Resources", "links", resourceLinkName);
            ResourceLink resourceLink = (await resourceLinkContainer.GetAsync(resourceLinkId)).Value;
            await resourceLink.DeleteAsync();
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;

            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            // With the container, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroup resourceGroup = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            GenericResourceData vNData = new GenericResourceData(Location.WestUS2)
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
            ResourceIdentifier vnId1 = resourceGroup.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", "vn1");
            ResourceIdentifier vnId2 = resourceGroup.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", "vn2");
            GenericResource vn1 = await subscription.GetGenericResources().CreateOrUpdateAsync(vnId1, vNData);
            GenericResource vn2 = await subscription.GetGenericResources().CreateOrUpdateAsync(vnId2, vNData);
            this.vn1 = vn1;
            this.vn2 = vn2;
        }
    }
}
