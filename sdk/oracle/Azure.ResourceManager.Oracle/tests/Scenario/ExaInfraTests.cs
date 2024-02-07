// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Oracle.Models;
using Azure.ResourceManager.Oracle.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Oracle.Tests.Scenario
{
    [TestFixture]
    public class ExaInfraTests : OracleManagementTestBase
    {
        public ExaInfraTests() : base(true)
        {
        }
        [SetUp]
        public async Task ClearAndInitialize()
        {
            await CreateCommonClient();
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }
        [TestCase]
        public async Task TestExaInfraOperations()
        {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync("SDKtesting");
            CloudExadataInfrastructureCollection cloudExadataInfrastructureCollection = rg.GetCloudExadataInfrastructures();
            var cloudExadataInfrastructureName = "OFake_SdkExadata_test_1";
            CloudExadataInfrastructureData exadataInfrastructureData = GetDefaultCloudExadataInfrastructureData();

            // Create
            var createExadataOperation = await cloudExadataInfrastructureCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            cloudExadataInfrastructureName, exadataInfrastructureData);
            await createExadataOperation.WaitForCompletionAsync();
            Assert.IsTrue(createExadataOperation.HasCompleted);
            Assert.IsTrue(createExadataOperation.HasValue);

            // Get
            Response<CloudExadataInfrastructureResource> getExaInfraResponse = await cloudExadataInfrastructureCollection.GetAsync(cloudExadataInfrastructureName);
            CloudExadataInfrastructureResource exaInfraResource = getExaInfraResponse.Value;
            Assert.IsNotNull(exaInfraResource);
        }
    }
}