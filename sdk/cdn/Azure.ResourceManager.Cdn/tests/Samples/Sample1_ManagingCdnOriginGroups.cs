// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_OriginGroups_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
#endregion Manage_OriginGroups_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests.Samples
{
    public class Sample1_ManagingCdnOriginGroups
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOriginGroups()
        {
            #region Snippet:Managing_OriginGroups_CreateAnOriginGroup
            // Create a new cdn profile
            string profileName = "myProfile";
            var input1 = new ProfileData(AzureLocation.WestUS, new Models.Sku { Name = SkuName.StandardMicrosoft });
            ProfileCreateOrUpdateOperation lro1 = await resourceGroup.GetProfiles().CreateOrUpdateAsync(true, profileName, input1);
            Profile profile = lro1.Value;
            // Get the cdn endpoint collection from the specific profile and create an endpoint
            string endpointName = "myEndpoint";
            var input2 = new CdnEndpointData(AzureLocation.WestUS)
            {
                IsHttpAllowed = true,
                IsHttpsAllowed = true,
                OptimizationType = OptimizationType.GeneralWebDelivery
            };
            DeepCreatedOrigin deepCreatedOrigin = new DeepCreatedOrigin("myOrigin")
            {
                HostName = "testsa4dotnetsdk.blob.core.windows.net",
                Priority = 3,
                Weight = 100
            };
            input2.Origins.Add(deepCreatedOrigin);
            CdnEndpointCreateOrUpdateOperation lro2 = await profile.GetCdnEndpoints().CreateOrUpdateAsync(true, endpointName, input2);
            CdnEndpoint endpoint = lro2.Value;
            // Get the cdn origin group collection from the specific endpoint and create an origin group
            string originGroupName = "myOriginGroup";
            var input3 = new CdnOriginGroupData();
            input3.Origins.Add(new WritableSubResource
            {
                Id = new ResourceIdentifier($"{endpoint.Id}/origins/myOrigin")
            });
            CdnOriginGroupCreateOrUpdateOperation lro3 = await endpoint.GetCdnOriginGroups().CreateOrUpdateAsync(true, originGroupName, input3);
            CdnOriginGroup originGroup = lro3.Value;
            #endregion Snippet:Managing_OriginGroups_CreateAnOriginGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListOriginGroups()
        {
            #region Snippet:Managing_OriginGroups_ListAllOriginGroups
            // First we need to get the cdn origin group collection from the specific endpoint
            Profile profile = await resourceGroup.GetProfiles().GetAsync("myProfile");
            CdnEndpoint endpoint = await profile.GetCdnEndpoints().GetAsync("myEndpoint");
            CdnOriginGroupCollection originGroupCollection = endpoint.GetCdnOriginGroups();
            // With GetAllAsync(), we can get a list of the origin group in the collection
            AsyncPageable<CdnOriginGroup> response = originGroupCollection.GetAllAsync();
            await foreach (CdnOriginGroup originGroup in response)
            {
                Console.WriteLine(originGroup.Data.Name);
            }
            #endregion Snippet:Managing_OriginGroups_ListAllOriginGroups
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateOriginGroups()
        {
            #region Snippet:Managing_OriginGroups_UpdateAnOriginGroup
            // First we need to get the cdn origin group collection from the specific endpoint
            Profile profile = await resourceGroup.GetProfiles().GetAsync("myProfile");
            CdnEndpoint endpoint = await profile.GetCdnEndpoints().GetAsync("myEndpoint");
            CdnOriginGroupCollection originGroupCollection = endpoint.GetCdnOriginGroups();
            // Now we can get the origin group with GetAsync()
            CdnOriginGroup originGroup = await originGroupCollection.GetAsync("myOriginGroup");
            // With UpdateAsync(), we can update the origin group
            OriginGroupUpdateOptions input = new OriginGroupUpdateOptions()
            {
                HealthProbeSettings = new HealthProbeParameters
                {
                    ProbePath = "/healthz",
                    ProbeRequestType = HealthProbeRequestType.Head,
                    ProbeProtocol = ProbeProtocol.Https,
                    ProbeIntervalInSeconds = 60
                }
            };
            CdnOriginGroupUpdateOperation lro = await originGroup.UpdateAsync(true, input);
            originGroup = lro.Value;
            #endregion Snippet:Managing_OriginGroups_UpdateAnOriginGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteOriginGroups()
        {
            #region Snippet:Managing_OriginGroups_DeleteAnOriginGroup
            // First we need to get the cdn origin group collection from the specific endpoint
            Profile profile = await resourceGroup.GetProfiles().GetAsync("myProfile");
            CdnEndpoint endpoint = await profile.GetCdnEndpoints().GetAsync("myEndpoint");
            CdnOriginGroupCollection originGroupCollection = endpoint.GetCdnOriginGroups();
            // Now we can get the origin group with GetAsync()
            CdnOriginGroup originGroup = await originGroupCollection.GetAsync("myOriginGroup");
            // With DeleteAsync(), we can delete the origin group
            await originGroup.DeleteAsync(true);
            #endregion Snippet:Managing_OriginGroups_DeleteAnOriginGroup
        }

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion

            #region Snippet:Readme_GetResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with a specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(true, rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;
            #endregion

            this.resourceGroup = resourceGroup;
        }
    }
}
