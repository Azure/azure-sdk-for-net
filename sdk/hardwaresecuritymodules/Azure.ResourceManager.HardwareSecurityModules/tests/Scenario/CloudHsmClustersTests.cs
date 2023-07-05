// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
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

        [TestCase]
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
            var operation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, cloudHsmClusterBody);
            CloudHsmClusterResource cloudHsmClusterResult = operation.Value;
            Assert.AreEqual(resourceName, cloudHsmClusterResult.Data.Name);
        }
    }
}
