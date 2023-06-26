// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hardwaresecuritymodules.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Hardwaresecuritymodules.Tests
{
    public class CloudHsmClustersTests : HardwaresecuritymodulesManagementTestBase
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

            CloudHsmCluster cloudHsmClusterBody = new CloudHsmCluster(new AzureLocation("eastus2"))
            {
                SecurityDomain = new CloudHsmClusterSecurityDomainProperties()
                {
                    FipsState = 2,
                },
                Sku = new CloudHsmClusterSku(CloudHsmClusterSkuName.StandardB1, CloudHsmClusterSkuFamily.B),
                Tags =
                {
                    ["Dept"] = "hsm",
                    ["Env"] = "df",
                },
            };

            ArmOperation<CloudHsmCluster> armOperationChsm = await ResourceGroupResource.CreateOrUpdateCloudHsmClusterAsync(WaitUntil.Completed, resourceName, cloudHsmClusterBody);
            CloudHsmCluster cloudHsmClusterResult = armOperationChsm.Value;
            Assert.AreEqual(resourceName, cloudHsmClusterResult.Name);
        }
    }
}
