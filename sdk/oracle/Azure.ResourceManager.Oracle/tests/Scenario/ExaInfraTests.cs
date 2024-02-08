// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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

            // Check Existence
            Response<bool> exaInfraExists = await cloudExadataInfrastructureCollection.ExistsAsync("OFake_SdkExadata_test_1");
            bool checkResult = exaInfraExists.Value;
            Assert.IsTrue(checkResult);

            // Get if exists - exists
            NullableResponse<CloudExadataInfrastructureResource> getExaInfraNullableResponse = await cloudExadataInfrastructureCollection.GetIfExistsAsync(cloudExadataInfrastructureName);
            CloudExadataInfrastructureResource exaInfraResource2 = getExaInfraNullableResponse.Value;
            Assert.IsNotNull(exaInfraResource2);

            // Get if exists - not exist
            NullableResponse<CloudExadataInfrastructureResource> getExaInfraNullableResponse2 = await cloudExadataInfrastructureCollection.GetIfExistsAsync("OFake_not_exist");
            Assert.IsFalse(getExaInfraNullableResponse2.HasValue);

            // ListByResourceGroup
            AsyncPageable<CloudExadataInfrastructureResource> ExaInfras = cloudExadataInfrastructureCollection.GetAllAsync();
            List<CloudExadataInfrastructureResource> exaInfraResult = await ExaInfras.ToEnumerableAsync();
            Assert.NotNull(exaInfraResult);
            Assert.IsTrue(exaInfraResult.Count >= 1);
        }
    }
}