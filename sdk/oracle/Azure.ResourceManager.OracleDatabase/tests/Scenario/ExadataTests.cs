// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class ExadataTests : OracleDatabaseManagementTestBase
    {
        private const string DefaultVmClusterKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDAIdCVcZiGBSybKTvFBfrfVhYWRImneQB9ovsU/GYqPLyDpXkpdGusYc5OL6zHq27uKtJ+//0wCoENJmvBjiRMUWMKZ4NcUkxVWj+ipJTFDO1t3KRkpDCLQEBEihOaNHHN9j2ZggUxOQBgCIwjjH+B+6Z1KpvpmvDhbMhmmZJ6R4yJI+fE80SFCV0G5sZuq38W+eK6FQRNINCmayWLNYw8sk1cBzqxMTo7OeVRxjyfQYRS1o+sC1CkxT7BYw30qY/xzR45yxkRZ5FkugPR5MQ1NApRPGNOuZD1MRwcG1AZ5JfiX9ckz5xaKjfm0hhfwh/qT7mH6fXiX7nAmkvLxu6Xnzy3aign4e99QSWPkpjJ0X1gluLzR7/gwYMjA6sfflRNe/FP937kJTIa1F5BonWe9eS580IXoTUNaiAanOEf5fBdji4JEDk7nXKV7kTECkCX9ZDWwB8q/ayIXwmNMCgxCpdx2F6UWOGvF5UWJkyD3BxTgMOiPwxMMEvCGIIdaGU= generated-by-azure";

        private CloudExadataInfrastructureCollection _exaInfraCollection;
        private CloudVmClusterCollection _vmClusterCollection;
        private string _exadataInfraName;
        private string _vmClusterName;
        private static CloudExadataInfrastructureResource _exaInfraResource;
        private static CloudVmClusterResource _vmClusterResource;

        public ExadataTests() : base(true, RecordedTestMode.Playback)
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
        public async Task TestExadataOperations()
        {
            _exaInfraResource = await CreateExadataInfrastructureScenario();

            _vmClusterResource = await CreateVmClusterScenario();

            await DeleteVmClusterScenario(_vmClusterResource);

            await DeleteExadataInfrastructureScenario(_exaInfraResource);
        }

        private async Task<List<string>> GetDbServerOcids(CloudExadataInfrastructureResource exaInfraResource) {
            List<string> dbServerOcids = new();
            OracleDBServerCollection dbServerCollection = exaInfraResource.GetOracleDBServers();
            AsyncPageable<OracleDBServerResource> dbServers = dbServerCollection.GetAllAsync();
            await foreach (OracleDBServerResource dbServer in dbServers) {
                dbServerOcids.Add(dbServer.Data.Properties.DBServerOcid);
            }
            return dbServerOcids;
        }

        private async Task<CloudExadataInfrastructureResource> CreateExadataInfrastructureScenario() {
            _exaInfraCollection = await GetCloudExadataInfrastructureCollectionAsync(DefaultResourceGroupName);
            _exadataInfraName = Recording.GenerateAssetName("OFake_NetSdkTestExaInfraLa");

            // Create
            var createExaInfraOperation = await _exaInfraCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            _exadataInfraName, GetDefaultExaInfraData(_exadataInfraName));
            await createExaInfraOperation.WaitForCompletionAsync();
            Assert.IsTrue(createExaInfraOperation.HasCompleted);
            Assert.IsTrue(createExaInfraOperation.HasValue);

            // Get
            Response<CloudExadataInfrastructureResource> getExaInfraResponse = await _exaInfraCollection.GetAsync(_exadataInfraName);
            CloudExadataInfrastructureResource exaInfraResource = getExaInfraResponse.Value;
            Assert.IsNotNull(exaInfraResource);
            return exaInfraResource;
        }

        private async Task DeleteExadataInfrastructureScenario(CloudExadataInfrastructureResource exaInfraResource) {
            if (exaInfraResource != null) {
                var deleteExaInfraOperation = await exaInfraResource.DeleteAsync(WaitUntil.Completed);
                await deleteExaInfraOperation.WaitForCompletionResponseAsync();
                Assert.IsTrue(deleteExaInfraOperation.HasCompleted);
            }
        }

        private async Task DeleteVmClusterScenario(CloudVmClusterResource vmClusterResource) {
            if (vmClusterResource != null) {
                var deleteVmClusterOperation = await vmClusterResource.DeleteAsync(WaitUntil.Completed);
                await deleteVmClusterOperation.WaitForCompletionResponseAsync();
                Assert.IsTrue(deleteVmClusterOperation.HasCompleted);
            }
        }

        private async Task<CloudVmClusterResource> CreateVmClusterScenario() {
            _vmClusterCollection = await GetCloudVmClusterCollectionAsync(DefaultResourceGroupName);
            _vmClusterName = Recording.GenerateAssetName("OFake_NetSdkTestVmCluster");

            // Create
            var createVmClusterOperation = await _vmClusterCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            _vmClusterName, await GetDefaultVmClusterData());
            await createVmClusterOperation.WaitForCompletionAsync();

            // Get
            Response<CloudVmClusterResource> getVmClusterResponse = await _vmClusterCollection.GetAsync(_vmClusterName);
            return getVmClusterResponse.Value;
        }

        private CloudExadataInfrastructureData GetDefaultExaInfraData(string exaInfraName) {
            string shape = "Exadata.X9M";
            CloudExadataInfrastructureProperties exaInfraProperties = new CloudExadataInfrastructureProperties(shape, exaInfraName) {
                ComputeCount = 2,
                StorageCount = 3,
            };
            return new CloudExadataInfrastructureData(_location, new List<string>{ "2" }) {
                Properties = exaInfraProperties
            };
        }

        private async Task<CloudVmClusterData> GetDefaultVmClusterData() {
            CloudVmClusterProperties vmClusterProperties = GetDefaultVmClusterProperties();

            List<string> dbServerOcids = await GetDbServerOcids(_exaInfraResource);
            // A minimum of 2 database servers is required.
            if (dbServerOcids[0] != null) {
                vmClusterProperties.DBServerOcids.Add(dbServerOcids[0]);
            }
            if (dbServerOcids[1] != null) {
                vmClusterProperties.DBServerOcids.Add(dbServerOcids[1]);
            }

            return new CloudVmClusterData(_location) {
                Properties = vmClusterProperties
            };
        }

        private CloudVmClusterProperties GetDefaultVmClusterProperties() {
            string hostName = "net-sdk-test";
            int cpuCoreCount = 4;
            ResourceIdentifier cloudExadataInfrastructureId = _exaInfraResource.Data.Id;
            List<string> sshPublicKeys = new List<string>() {DefaultVmClusterKey};
            string giVersion = "19.0.0.0";
            ResourceIdentifier vnetId = new ResourceIdentifier(string.Format(VnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName));
            ResourceIdentifier subnetId = new ResourceIdentifier(string.Format(SubnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName, DefaultSubnetName));
            string displayName = _vmClusterName;

            return new CloudVmClusterProperties(hostName, cpuCoreCount, cloudExadataInfrastructureId, sshPublicKeys, vnetId, giVersion, subnetId, displayName) {
                LicenseModel = OracleLicenseModel.LicenseIncluded,
                ClusterName = "TestVmClust",
                MemorySizeInGbs = 90,
                DBNodeStorageSizeInGbs = 180,
                DataStorageSizeInTbs = 2.0,
                DataStoragePercentage = 80,
                IsLocalBackupEnabled = false,
                IsSparseDiskgroupEnabled = false,
                TimeZone = "UTC"
            };
        }
    }
}
