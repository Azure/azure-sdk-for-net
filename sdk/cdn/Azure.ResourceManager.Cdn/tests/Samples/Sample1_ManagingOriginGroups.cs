// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_OriginGroups_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
#endregion Manage_OriginGroups_Namespaces
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests.Samples
{
    public class Sample1_ManagingOriginGroups
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOriginGroups()
        {
            #region Snippet:Managing_OriginGroups_CreateAnOriginGroup
            // Create a new CDN profile
            string profileName = "myProfile";
            var input1 = new ProfileData(Location.WestUS, new Sku { Name = SkuName.StandardMicrosoft });
            ProfileCreateOperation lro1 = await resourceGroup.GetProfiles().CreateOrUpdateAsync(profileName, input1);
            Profile profile = lro1.Value;
            // Get the endpoint collection from the specific profile and create an endpoint
            string endpointName = "myEndpoint";
            var input2 = new EndpointData(Location.WestUS)
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
            EndpointCreateOperation lro2 = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, input2);
            Endpoint endpoint = lro2.Value;
            // Get the origin group collection from the specific endpoint and create an origin group
            string originGroupName = "myOriginGroup";
            var input3 = new OriginGroupData();
            input3.Origins.Add(new WritableSubResource
            {
                Id = $"{endpoint.Id}/origins/myOrigin"
            });
            OriginGroupCreateOperation lro3 = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, input3);
            OriginGroup originGroup = lro3.Value;
            #endregion Snippet:Managing_OriginGroups_CreateAnOriginGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListOriginGroups()
        {
            #region Snippet:Managing_OriginGroups_ListAllOriginGroups
            // First we need to get the origin group collection from the specific endpoint
            Profile profile = await resourceGroup.GetProfiles().GetAsync("myProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("myEndpoint");
            OriginGroupCollection originGroupCollection = endpoint.GetOriginGroups();
            // With GetAllAsync(), we can get a list of the origin group in the collection
            AsyncPageable<OriginGroup> response = originGroupCollection.GetAllAsync();
            await foreach (OriginGroup originGroup in response)
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
            // First we need to get the origin group collection from the specific endpoint
            Profile profile = await resourceGroup.GetProfiles().GetAsync("myProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("myEndpoint");
            OriginGroupCollection originGroupCollection = endpoint.GetOriginGroups();
            // Now we can get the origin group with GetAsync()
            OriginGroup originGroup = await originGroupCollection.GetAsync("myOriginGroup");
            // With UpdateAsync(), we can update the origin group
            OriginGroupUpdateParameters input = new OriginGroupUpdateParameters()
            {
                HealthProbeSettings = new HealthProbeParameters
                {
                    ProbePath = "/healthz",
                    ProbeRequestType = HealthProbeRequestType.Head,
                    ProbeProtocol = ProbeProtocol.Https,
                    ProbeIntervalInSeconds = 60
                }
            };
            OriginGroupUpdateOperation lro = await originGroup.UpdateAsync(input);
            originGroup = lro.Value;
            #endregion Snippet:Managing_OriginGroups_UpdateAnOriginGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteOriginGroups()
        {
            #region Snippet:Managing_OriginGroups_DeleteAnOriginGroup
            // First we need to get the origin group collection from the specific endpoint
            Profile profile = await resourceGroup.GetProfiles().GetAsync("myProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("myEndpoint");
            OriginGroupCollection originGroupCollection = endpoint.GetOriginGroups();
            // Now we can get the origin group with GetAsync()
            OriginGroup originGroup = await originGroupCollection.GetAsync("myOriginGroup");
            // With DeleteAsync(), we can delete the origin group
            await originGroup.DeleteAsync();
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
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;
            #endregion

            this.resourceGroup = resourceGroup;
        }
    }
}
