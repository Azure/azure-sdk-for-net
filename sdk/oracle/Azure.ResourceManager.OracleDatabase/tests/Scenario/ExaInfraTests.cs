// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.OracleDatabase.Models;
using System;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class ExaInfraTests : OracleDatabaseManagementTestBase
    {
        public ExaInfraTests() : base(true)
        {
        }
        [SetUp]
        public async Task ClearAndInitialize()
        {
            Console.WriteLine("HERE: ClearAndInitialize");
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback){
                await CreateCommonClient();
            }
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            Console.WriteLine("HERE: Cleanup");
            CleanupResourceGroups();
        }
        [TestCase]
        [RecordedTest]
        public async Task TestExaInfraOperations()
        {
            Console.WriteLine("HERE: TestExaInfraOperations");
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await TryRegisterResourceGroupAsync(ResourceGroupsOperations, "eastus", resourceGroupName);
            CloudExadataInfrastructureCollection cloudExadataInfrastructureCollection = await GetCloudExadataInfrastructureCollectionAsync(resourceGroupName);
            var cloudExadataInfrastructureName = Recording.GenerateAssetName("OFake_Jamie");
            CloudExadataInfrastructureData exadataInfrastructureData = GetDefaultCloudExadataInfrastructureData(cloudExadataInfrastructureName);

            // Create
            Console.WriteLine("HERE: TestExaInfraOperations Create");
            var createExadataOperation = await cloudExadataInfrastructureCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            cloudExadataInfrastructureName, exadataInfrastructureData);
            await createExadataOperation.WaitForCompletionAsync();
            Assert.IsTrue(createExadataOperation.HasCompleted);
            Assert.IsTrue(createExadataOperation.HasValue);

            // Get
            Console.WriteLine("HERE: TestExaInfraOperations Get");
            Response<CloudExadataInfrastructureResource> getExaInfraResponse = await cloudExadataInfrastructureCollection.GetAsync(cloudExadataInfrastructureName);
            CloudExadataInfrastructureResource exaInfraResource = getExaInfraResponse.Value;
            Assert.IsNotNull(exaInfraResource);

            // Delete
            Console.WriteLine("HERE: TestExaInfraOperations Delete");
            var deleteExaInfraOperation = await exaInfraResource.DeleteAsync(WaitUntil.Completed);
            await deleteExaInfraOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteExaInfraOperation.HasCompleted);
        }
    }
}