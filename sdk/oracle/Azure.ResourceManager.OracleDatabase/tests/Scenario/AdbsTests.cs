// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class AdbsTests : OracleDatabaseManagementTestBase
    {
        private AutonomousDatabaseCollection _adbsCollection;
        private string _adbsName;
        private AutonomousDatabaseResource _adbsResource;

        public AdbsTests() : base(true, RecordedTestMode.Playback)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) {
                await CreateCommonClient();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAdbsOperations()
        {
            _adbsResource = await CreateAdbsScenario();

            await DeleteAdbsScenario(_adbsResource);
        }

        private async Task<AutonomousDatabaseResource> CreateAdbsScenario() {
            _adbsCollection = await GetAutonomousDatabaseCollectionAsync(DefaultResourceGroupName);
            _adbsName = Recording.GenerateAssetName("OFakeNetSdkTestAdbs");

            // Create
            var createAdbsOperation = await _adbsCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            _adbsName, GetDefaultAdbsData());
            await createAdbsOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAdbsOperation.HasCompleted);
            Assert.IsTrue(createAdbsOperation.HasValue);

            // Get
            Response<AutonomousDatabaseResource> getAdbsResponse = await _adbsCollection.GetAsync(_adbsName);
            AutonomousDatabaseResource adbsResource = getAdbsResponse.Value;
            Assert.IsNotNull(adbsResource);
            return adbsResource;
        }

        private async Task DeleteAdbsScenario(AutonomousDatabaseResource adbsResource) {
            if (adbsResource != null) {
                var deleteAdbsOperation = await adbsResource.DeleteAsync(WaitUntil.Completed);
                await deleteAdbsOperation.WaitForCompletionResponseAsync();
                Assert.IsTrue(deleteAdbsOperation.HasCompleted);
            }
        }

        private AutonomousDatabaseData GetDefaultAdbsData() {
            AutonomousDatabaseProperties adbsProperties = GetDefaultAdbsProperties();
            return new AutonomousDatabaseData(_location) {
                Properties = adbsProperties
            };
        }

        private AutonomousDatabaseProperties GetDefaultAdbsProperties() {
            ResourceIdentifier vnetId = new ResourceIdentifier(string.Format(VnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName));
            ResourceIdentifier subnetId = new ResourceIdentifier(string.Format(SubnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName, DefaultSubnetName));

            return new AutonomousDatabaseProperties() {
            DisplayName = _adbsName,
            DBWorkload = AutonomousDatabaseWorkloadType.DW,
            ComputeCount = 2.0f,
            DatabaseComputeModel = OracleDatabaseComputeModel.Ecpu,
            DBVersion = "19c",
            DataStorageSizeInTbs = 1,
            AdminPassword = "NetSdkTestPass123",
            LicenseModel = OracleLicenseModel.LicenseIncluded,
            SubnetId = subnetId,
            VnetId = vnetId
            };
        }
    }
}
