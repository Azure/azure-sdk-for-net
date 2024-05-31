// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
using System;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class CloudVMClusterTests : OracleDatabaseManagementTestBase
    {
        private CloudVmClusterCollection _cloudVMClusterCollection;

        private CloudExadataInfrastructureResource _cloudExadataInfrastructureResource;

        private List<DbServerResource> _dbServerResources;

        private const string SubnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}/subnets/{3}";
        private const string VnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}";
        private const string DefaultSubnetName = "delegated";

        private const string DefaultVnetName = "SDKTestingVirtualNetwork";
        private const string DefaultResourceGroupName = "SDKTesting";

        private string _vmClusterName;

        public CloudVMClusterTests() : base(true, RecordedTestMode.Record)
        {
        }
        [SetUp]
        public async Task ClearAndInitialize()
        {
            Console.WriteLine("HERE: ClearAndInitialize");
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback){
                await CreateCommonClient();
            }
            await CreateExaInfra();
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        private async Task CreateExaInfra() {
            Console.WriteLine("HERE: CreateExaInfra");
            CloudExadataInfrastructureCollection cloudExadataInfrastructureCollection = await GetCloudExadataInfrastructureCollectionAsync(DefaultResourceGroupName);
            var cloudExadataInfrastructureName = Recording.GenerateAssetName("OFake_NetSdkTestExaInfra");
            CloudExadataInfrastructureData exadataInfrastructureData = GetDefaultCloudExadataInfrastructureData(cloudExadataInfrastructureName);
            _cloudVMClusterCollection = await GetCloudVmClusterCollectionAsync(DefaultResourceGroupName);

            // Create ExaInfra
            Console.WriteLine("HERE: CreateExaInfra Create ExaInfra");
            var createExadataOperation = await cloudExadataInfrastructureCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            cloudExadataInfrastructureName, exadataInfrastructureData);
            await createExadataOperation.WaitForCompletionAsync();

            // Get ExaInfra
            Console.WriteLine("HERE: CreateExaInfra Get ExaInfra");
            Response<CloudExadataInfrastructureResource> getExaInfraResponse = await cloudExadataInfrastructureCollection.GetAsync(cloudExadataInfrastructureName);
            _cloudExadataInfrastructureResource = getExaInfraResponse.Value;

            // List DBServers
            Console.WriteLine("HERE: CreateExaInfra List DBServers");
            DbServerCollection dbServerCollection = _cloudExadataInfrastructureResource.GetDbServers();
            AsyncPageable<DbServerResource> dbServers = dbServerCollection.GetAllAsync();
            _dbServerResources = await dbServers.ToEnumerableAsync();
        }

        private CloudVmClusterData GetCloudVmClusterData() {
            return new CloudVmClusterData(AzureLocation.EastUS);
            // return new CloudVmClusterData(AzureLocation.EastUS) {
            //     SubnetId = new ResourceIdentifier(string.Format(SubnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName, DefaultSubnetName)),
            //     CloudExadataInfrastructureId = _cloudExadataInfrastructureResource.Data.Id,
            //     CpuCoreCount = 4,
            //     DataStoragePercentage = 80,
            //     DataStorageSizeInTbs = 2,
            //     DbNodeStorageSizeInGbs = 120,
            //     DbServers = new List<string>() {_dbServerResources[0].Data.Ocid, _dbServerResources[1].Data.Ocid},
            //     ClusterName = "SDKCluster",
            //     DisplayName = _vmClusterName,
            //     GiVersion = "19.0.0.0",
            //     Hostname = "net-sdk-test",
            //     IsLocalBackupEnabled = false,
            //     IsSparseDiskgroupEnabled = false,
            //     LicenseModel = "LicenseIncluded",
            //     MemorySizeInGbs = 60,
            //     TimeZone = "UTC",
            //     VnetId = new ResourceIdentifier(string.Format(VnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName)),
            //     SshPublicKeys = new List<string>() {"ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDDrgWI+76BPb8E+/KRgM+JWizRyMuaX/Pdot14fXir+i0BoAOmfcgmO2D6L+5MfL0+ToXhhZmQZnH02h5t1gsTnlYgdAZfRv/qnAjyML5qXTyWSalKvwD9C3hPYMSQXoWk2cR2lrP1DWtOUWEht3ot+OFR0DJ0uTPo6dUyLqsPsFWJyZYn3KdztX8BFCy5T6u+b2Y2AUJ3/iooJeRt79V3zFJ705towYW2d+iBouThLLnKvbf27MnVd9AdM/EPt0kJiTj4NssixrXWGVWNREOdpWMccbK7VMc7vTbWhm/QdMMNQBjJk7JazxPhZQ+o7mdrrNZCVRuSgspBze04Imgl2pmoX+XD7TBMsEaNiePV7AuggR1/JncGnZztETLv90nClR+pvoYthgtneZ4xu68c3JATXb5KMgRa0afPR1eEZfwJzPXegsMGKskaIKhthZbBYBrJNSOppgTzNg6Wsj9qiyA4fm2GpkZoDGwGDGE2xFOS4CKe6ArTK3Onqi/HWiU= generated-by-azure"}
            // };
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCloudVMClusterOperations()
        {
            // Create
            Console.WriteLine("HERE: TestCloudVMClusterOperations Create");
            _vmClusterName = Recording.GenerateAssetName("OFake_NetSdkTestVmCluster");
            var createVmClusterOperation = await _cloudVMClusterCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            _vmClusterName, GetCloudVmClusterData());
            await createVmClusterOperation.WaitForCompletionAsync();
            Assert.IsTrue(createVmClusterOperation.HasCompleted);
            Assert.IsTrue(createVmClusterOperation.HasValue);

            // Get
            Response<CloudVmClusterResource> getVmClusterResponse = await _cloudVMClusterCollection.GetAsync(_vmClusterName);
            CloudVmClusterResource vmClusterResource = getVmClusterResponse.Value;
            Assert.IsNotNull(vmClusterResource);

            // // ListByResourceGroup
            // AsyncPageable<CloudVmClusterResource> vmClusters = _cloudVMClusterCollection.GetAllAsync();
            // List<CloudVmClusterResource> vmClusterResult = await vmClusters.ToEnumerableAsync();
            // Assert.NotNull(vmClusterResult);
            // Assert.IsTrue(vmClusterResult.Count >= 1);

            // // ListBySubscription
            // vmClusters = OracleExtensions.GetCloudVmClustersAsync(DefaultSubscription);
            // vmClusterResult = await vmClusters.ToEnumerableAsync();
            // Assert.NotNull(vmClusterResult);
            // Assert.IsTrue(vmClusterResult.Count >= 1);

            // // Delete
            // var deleteVmClusterOperation = await vmClusterResource.DeleteAsync(WaitUntil.Completed);
            // await deleteVmClusterOperation.WaitForCompletionResponseAsync();
            // Assert.IsTrue(deleteVmClusterOperation.HasCompleted);
        }
    }
}