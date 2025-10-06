// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HardwareSecurityModules.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HardwareSecurityModules.Tests
{
    public class CloudHsmClustersTests : HardwareSecurityModulesManagementTestBase
    {
        public CloudHsmClustersTests(bool isAsync)
        : base(isAsync)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUpForTests();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateCloudHsmClusterTest()
        {
            string resourceName = Recording.GenerateAssetName("sdkT");
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            var azureStorageBlobContainerUri = new Uri("https://myaccount.blob.core.windows.net/mycontainer");

            CloudHsmClusterData cloudHsmClusterBody = new CloudHsmClusterData(Location)
            {
                Sku = new CloudHsmClusterSku(CloudHsmClusterSkuFamily.B, CloudHsmClusterSkuName.StandardB1),
                Tags =
                {
                    ["Dept"] = "SDK Testing",
                    ["Env"] = "df",
                    ["UseMockHfc"] = "true",
                    ["MockHfcDelayInMs"] = "1"
                },
                //Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };

            //cloudHsmClusterBody.Identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            CloudHsmClusterCollection collection = ResourceGroupResource.GetCloudHsmClusters();
            var createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, cloudHsmClusterBody);
            CloudHsmClusterResource cloudHsmClusterResult = createOperation.Value;

            Assert.AreEqual(resourceName, cloudHsmClusterResult.Data.Name);
            ValidateCloudHsmResource(
                cloudHsmClusterResult.Data,
                DefaultSubscription.Data.SubscriptionId,
                ResourceGroupResource.Data.Name,
                resourceName,
                Location.Name,
                CloudHsmClusterSkuFamily.B.ToString(),
                CloudHsmClusterSkuName.StandardB1.ToString(),
                new Dictionary<string, string>(cloudHsmClusterBody.Tags));
                //ManagedServiceIdentityType.UserAssigned);

            var getOperation = await collection.GetAsync(resourceName);

            Assert.IsNotNull(getOperation.Value);
            ValidateCloudHsmResource(
                getOperation.Value.Data,
                DefaultSubscription.Data.SubscriptionId,
                ResourceGroupResource.Data.Name,
                resourceName,
                Location.Name,
                CloudHsmClusterSkuFamily.B.ToString(),
                CloudHsmClusterSkuName.StandardB1.ToString(),
                new Dictionary<string, string>(cloudHsmClusterBody.Tags));
                //ManagedServiceIdentityType.UserAssigned);

            var getAllOperation = collection.GetAllAsync();
            int cloudhsmCount = 0;
            await foreach (CloudHsmClusterResource cloudHsmResource in getAllOperation)
            {
                if (cloudHsmResource.Id == cloudHsmClusterResult.Id)
                {
                    cloudhsmCount++;
                    break;
                }
            }
            Assert.AreEqual(cloudhsmCount, 1);
        }

        private void ValidateCloudHsmResource(
            CloudHsmClusterData cloudHsmClusterData,
            string expecrtedSubId,
            string expecrtedRgName,
            string expectedResourceName,
            string expectedResourceLocation,
            string expectedSkuFamily,
            string expectedSkuName,
            Dictionary<string, string> expectedTags
            //ManagedServiceIdentityType expectedIdentityType,
            //int managedIdentityExpextedCount = 1
            )
        {
            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.HardwareSecurityModules/cloudHsmClusters/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expecrtedSubId, expecrtedRgName, expectedResourceName);

            Assert.NotNull(cloudHsmClusterData);
            Assert.AreEqual(expectedResourceId, cloudHsmClusterData.Id.ToString());
            Assert.AreEqual(expectedResourceLocation, cloudHsmClusterData.Location.Name);
            Assert.AreEqual(expectedResourceName, cloudHsmClusterData.Name);
            Assert.NotNull(cloudHsmClusterData.Sku);
            Assert.AreEqual(expectedSkuFamily, cloudHsmClusterData.Sku.Family.ToString());
            Assert.AreEqual(expectedSkuName, cloudHsmClusterData.Sku.Name.ToString());
            Assert.NotNull(cloudHsmClusterData.Tags);
            Assert.True(expectedTags.Count == cloudHsmClusterData.Tags.Count && !expectedTags.Except(cloudHsmClusterData.Tags).Any());
            //Assert.AreEqual(expectedIdentityType, cloudHsmClusterData.Identity.ManagedServiceIdentityType);
            //Assert.AreEqual(managedIdentityExpextedCount, cloudHsmClusterData.Identity.UserAssignedIdentities.Count);
        }

        private async Task<GenericResource> CreateUserAssignedIdentityAsync()
        {
            string userAssignedIdentityName = Recording.GenerateAssetName("testRi-");
            ResourceIdentifier userIdentityId = new ResourceIdentifier($"{ResourceGroupResource.Id}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{userAssignedIdentityName}");
            var input = new GenericResourceData(Location);
            var response = await GenericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, userIdentityId, input);
            return response.Value;
        }
    }
}
