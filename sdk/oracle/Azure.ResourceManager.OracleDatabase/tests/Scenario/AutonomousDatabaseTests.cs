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
using System.Runtime.CompilerServices;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class AutonomousDatabaseTests : OracleDatabaseManagementTestBase
    {
        private AutonomousDatabaseCollection _autonomousDatabaseCollection;

        private const string SubnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}/subnets/{3}";
        private const string VnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}";
        private const string DefaultSubnetName = "delegated";

        private const string DefaultVnetName = "NetSdkTestVnet";
        private const string DefaultResourceGroupName = "NetSdkTestRg";

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
            Console.WriteLine("HERE: GetAutonomousDatabaseData");
            Console.WriteLine("HERE: SubnetId: " + string.Format(SubnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName, DefaultSubnetName));
            Console.WriteLine("HERE: VnetId " + string.Format(VnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName));
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

        private AutonomousDatabasePatch GetAutonomousDatabasePatch(string tagName, string tagValue) {
            // TODO
            ChangeTrackingDictionary<string, string> tags = new ChangeTrackingDictionary<string, string>
            {
                new KeyValuePair<string, string>(tagName, tagValue)
            };
            var customerContact = new CustomerContact() {
                Email = Recording.GenerateAssetName("Email")
            };
            AutonomousMaintenanceScheduleType autonomousMaintenanceScheduleType = new AutonomousMaintenanceScheduleType();
            IList<CustomerContact> customerContacts = new List<CustomerContact>{customerContact};
            ScheduledOperationsTypeUpdate scheduledOperationsTypeUpdate = new ScheduledOperationsTypeUpdate();
            DatabaseEditionType databaseEditionType = new DatabaseEditionType();
            OpenModeType openModeType = new OpenModeType();
            PermissionLevelType permissionLevelType = new PermissionLevelType();
            RoleType roleType = new RoleType();
            return new AutonomousDatabasePatch(tags, default, autonomousMaintenanceScheduleType,
            default, default, customerContacts, default, default, _autonomousDatabaseName, true, true, default, true, true,
            LicenseModel.LicenseIncluded, scheduledOperationsTypeUpdate, databaseEditionType, default, openModeType, permissionLevelType,
            roleType, default, new List<string>{}, default);
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
            Console.WriteLine("HERE: TestAutonomousDatabaseOperations Get");
            Response<AutonomousDatabaseResource> getAutonomousDatabaseResponse = await _autonomousDatabaseCollection.GetAsync(_autonomousDatabaseName);
            AutonomousDatabaseResource autonomousDatabaseResource = getAutonomousDatabaseResponse.Value;
            Assert.IsNotNull(autonomousDatabaseResource);

            // ListByResourceGroup
            Console.WriteLine("HERE: TestAutonomousDatabaseOperations ListByResourceGroup");
            AsyncPageable<AutonomousDatabaseResource> autonomousDatabases = _autonomousDatabaseCollection.GetAllAsync();
            List<AutonomousDatabaseResource> autonomousDatabaseResult = await autonomousDatabases.ToEnumerableAsync();
            Assert.NotNull(autonomousDatabaseResult);
            Assert.IsTrue(autonomousDatabaseResult.Count >= 1);

            // ListBySubscription
            Console.WriteLine("HERE: TestAutonomousDatabaseOperations ListBySubscription");
            autonomousDatabases = OracleDatabaseExtensions.GetAutonomousDatabasesAsync(DefaultSubscription);
            autonomousDatabaseResult = await autonomousDatabases.ToEnumerableAsync();
            Assert.NotNull(autonomousDatabaseResult);
            Assert.IsTrue(autonomousDatabaseResult.Count >= 1);

            // // Update
            // Console.WriteLine("HERE: TestAutonomousDatabaseOperations Update");
            // var tagName = Recording.GenerateAssetName("TagName");
            // var tagValue = Recording.GenerateAssetName("TagValue");
            // AutonomousDatabasePatch adbsParameter = GetAutonomousDatabasePatch(tagName, tagValue);
            // // AutonomousDatabasePatch adbsParameter = new() {
            // //     Tags = tags
            // // };
            // var updateAdbsOperation = await autonomousDatabaseResource.UpdateAsync(WaitUntil.Completed, adbsParameter);
            // Assert.IsTrue(updateAdbsOperation.HasCompleted);
            // Assert.IsTrue(updateAdbsOperation.HasValue);

            // // Get after Update
            // Console.WriteLine("HERE: TestExaInfraOperations Get2");
            // getAutonomousDatabaseResponse = await _autonomousDatabaseCollection.GetAsync(_autonomousDatabaseName);
            // autonomousDatabaseResource = getAutonomousDatabaseResponse.Value;
            // Assert.IsNotNull(autonomousDatabaseResource);
            // Assert.IsTrue(autonomousDatabaseResource.Data.Tags.ContainsKey(tagName));

            // Delete
            Console.WriteLine("HERE: TestAutonomousDatabaseOperations Delete");
            var deleteAutonomousDatabaseOperation = await autonomousDatabaseResource.DeleteAsync(WaitUntil.Completed);
            await deleteAutonomousDatabaseOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteAutonomousDatabaseOperation.HasCompleted);
        }
    }
}