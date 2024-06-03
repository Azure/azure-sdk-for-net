// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
using System;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class AutonomousDatabaseTests : OracleDatabaseManagementTestBase
    {
        private AutonomousDatabaseCollection _autonomousDatabaseCollection;

        private const string SubnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}/subnets/{3}";
        private const string VnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}";
        private const string DefaultSubnetName = "delegated";

        private const string DefaultVnetName = "SDKTestingVirtualNetwork";
        private const string DefaultResourceGroupName = "SDKTesting";

        private string _autonomousDatabaseName;

        public AutonomousDatabaseTests() : base(true, RecordedTestMode.Record)
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
            CleanupResourceGroups();
        }

        private AutonomousDatabaseData GetAutonomousDatabaseData() {
            return new AutonomousDatabaseData(AzureLocation.EastUS) {
                DisplayName = _autonomousDatabaseName,
                DataBaseType = DataBaseType.Regular,
                DbWorkload = WorkloadType.DW,
                DbVersion = "19c",
                CpuCoreCount = 2,
                DataStorageSizeInTbs = 1,
                AdminPassword = "NetSdkTestPass123",
                LicenseModel = LicenseModel.LicenseIncluded,
                SubnetId = new ResourceIdentifier(string.Format(SubnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName, DefaultSubnetName)),
                VnetId = new ResourceIdentifier(string.Format(VnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName)),
            };
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAutonomousDatabaseOperations()
        {
            _autonomousDatabaseCollection = await GetAutonomousDatabaseCollectionAsync(DefaultResourceGroupName);

            // Create
            Console.WriteLine("HERE: TestAutonomousDatabaseOperations Create");
            _autonomousDatabaseName = Recording.GenerateAssetName("OFakeNetSdkTestAdbs");
            var createAutonomousDatabaseOperation = await _autonomousDatabaseCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            _autonomousDatabaseName, GetAutonomousDatabaseData());
            await createAutonomousDatabaseOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAutonomousDatabaseOperation.HasCompleted);
            Assert.IsTrue(createAutonomousDatabaseOperation.HasValue);

            // Get
            Response<AutonomousDatabaseResource> getAutonomousDatabaseResponse = await _autonomousDatabaseCollection.GetAsync(_autonomousDatabaseName);
            AutonomousDatabaseResource autonomousDatabaseResource = getAutonomousDatabaseResponse.Value;
            Assert.IsNotNull(autonomousDatabaseResource);

            // // ListByResourceGroup
            // AsyncPageable<AutonomousDatabaseResource> autonomousDatabases = _autonomousDatabaseCollection.GetAllAsync();
            // List<AutonomousDatabaseResource> autonomousDatabaseResult = await autonomousDatabases.ToEnumerableAsync();
            // Assert.NotNull(autonomousDatabaseResult);
            // Assert.IsTrue(autonomousDatabaseResult.Count >= 1);

            // // ListBySubscription
            // autonomousDatabases = OracleExtensions.GetAutonomousDatabaseAsync(DefaultSubscription);
            // autonomousDatabaseResult = await autonomousDatabases.ToEnumerableAsync();
            // Assert.NotNull(autonomousDatabaseResult);
            // Assert.IsTrue(autonomousDatabaseResult.Count >= 1);

            // // Delete
            // var deleteAutonomousDatabaseOperation = await autonomousDatabaseResource.DeleteAsync(WaitUntil.Completed);
            // await deleteAutonomousDatabaseOperation.WaitForCompletionResponseAsync();
            // Assert.IsTrue(deleteAutonomousDatabaseOperation.HasCompleted);
        }
    }
}