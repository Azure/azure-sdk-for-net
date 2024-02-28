// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Snippet:Manage_WebPubSub_Namespaces
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.WebPubSub.Models;
using NUnit.Framework;
#endregion Snippet:Manage_WebPubSub_Namespaces

namespace Azure.ResourceManager.WebPubSub.Tests.Samples
{
    public class Sample1_ManagingWebPubSub
    {
        private ResourceGroupResource resourceGroup;

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Managing_Resource_Groups_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion

            #region Snippet:Managing_Resource_Groups_GetResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the Colletion, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ResourceGroupResource resourceGroup = await rgCollection.CreateOrUpdate(WaitUntil.Completed, rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
            #endregion

            this.resourceGroup = resourceGroup;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_WebPubSub_CreateWebPubSub
            WebPubSubCollection WebPubSubColletion = resourceGroup.GetWebPubSubs();

            string webPubSubName = "myWebPubSubName";

            // Use the same location as the resource group
            IList<LiveTraceCategory> categories = new List<LiveTraceCategory>();
            categories.Add(new LiveTraceCategory("category-01", "true"));

            AclAction aclAction = new AclAction("Deny");
            IList<WebPubSubRequestType> allow = new List<WebPubSubRequestType>();
            IList<WebPubSubRequestType> deny = new List<WebPubSubRequestType>();
            deny.Add(new WebPubSubRequestType("RESTAPI"));
            PublicNetworkAcls publicNetwork = new PublicNetworkAcls(allow, deny, null);
            IList<PrivateEndpointAcl> privateEndpoints = new List<PrivateEndpointAcl>();

            List<ResourceLogCategory> resourceLogCategory = new List<ResourceLogCategory>()
            {
                new ResourceLogCategory(){ Name = "category1", Enabled = "false" }
            };
            WebPubSubData data = new WebPubSubData(AzureLocation.WestUS2)
            {
                Sku = new BillingInfoSku("Standard_S1"),
                LiveTraceConfiguration = new LiveTraceConfiguration("true", categories),
                NetworkAcls = new WebPubSubNetworkAcls(aclAction, publicNetwork, privateEndpoints, null),
                ResourceLogConfiguration = new ResourceLogConfiguration(resourceLogCategory, null),
            };

            WebPubSubResource webPubSub = await (await WebPubSubColletion.CreateOrUpdateAsync(WaitUntil.Started, webPubSubName, data)).WaitForCompletionAsync();

            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_WebPubSub_ListAllWebPubSub
            WebPubSubCollection WebPubSubColletion = resourceGroup.GetWebPubSubs();

            AsyncPageable<WebPubSubResource> response = WebPubSubColletion.GetAllAsync();
            await foreach (WebPubSubResource WebPubSub in response)
            {
                Console.WriteLine(WebPubSub.Data.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_WebPubSub_GetWebPubSub
            WebPubSubCollection WebPubSubColletion = resourceGroup.GetWebPubSubs();

            WebPubSubResource webPubSub = await WebPubSubColletion.GetAsync("myWebPubSubName");
            Console.WriteLine(webPubSub.Data.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteVirtualWebPubSub()
        {
            #region Snippet:Managing_WebPubSub_DeleteWebPubSub
            WebPubSubCollection WebPubSubColletion = resourceGroup.GetWebPubSubs();

            WebPubSubResource webPubSub = await WebPubSubColletion.GetAsync("myWebPubSubName");
            await webPubSub.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
    }
}
