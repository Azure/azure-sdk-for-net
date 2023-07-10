// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HardwareSecurityModules.Models;
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

        [RecordedTest]
        public async Task CreateOrUpdateCloudHsmClusterTest()
        {
            string resourceName = Recording.GenerateAssetName("CloudhsmSDKTest");

            CloudHsmClusterData cloudHsmClusterBody = new CloudHsmClusterData(Location)
            {
                SecurityDomain = new CloudHsmClusterSecurityDomainProperties()
                {
                    FipsState = 2,
                },
                Sku = new CloudHsmClusterSku(CloudHsmClusterSkuFamily.B, CloudHsmClusterSkuName.StandardB1),
                Tags =
                {
                    ["Dept"] = "SDK Testing",
                    ["Env"] = "df",
                },
            };

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
                (int)cloudHsmClusterBody.SecurityDomain.FipsState,
                new Dictionary<string, string>(cloudHsmClusterBody.Tags));

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
                (int)cloudHsmClusterBody.SecurityDomain.FipsState,
                new Dictionary<string, string>(cloudHsmClusterBody.Tags));

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
            int expectedFipsState,
            Dictionary<string, string> expectedTags
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
            Assert.NotNull(cloudHsmClusterData.SecurityDomain);
            Assert.AreEqual(expectedFipsState, cloudHsmClusterData.SecurityDomain.FipsState);
        }
    }
}
