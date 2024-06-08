// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;
using System;
using Azure.ResourceManager.OracleDatabase.Models;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class CloudVMClusterTests : OracleDatabaseManagementTestBase
    {
        private CloudVmClusterCollection _cloudVMClusterCollection;

        private CloudExadataInfrastructureResource _cloudExadataInfrastructureResource;

        private const string SubnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}/subnets/{3}";
        private const string VnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}";
        private const string DefaultSubnetName = "delegated";

        private const string DefaultVnetName = "NetSdkTestVnet";
        private const string DefaultResourceGroupName = "NetSdkTestRg";

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
            // DeleteExaInfra();
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
        }

        private void DeleteExaInfra() {
            // Delete ExaInfra
            if (_cloudExadataInfrastructureResource != null) {
                var deleteExaInfraOperation = _cloudExadataInfrastructureResource.DeleteAsync(WaitUntil.Completed);
            }
        }

        private CloudVmClusterData GetCloudVmClusterData() {
            CloudVmClusterProperties cloudVmClusterProperties = GetCloudVmClusterProperties();
            return new CloudVmClusterData(AzureLocation.EastUS) {
                Properties = cloudVmClusterProperties
            };
        }

        private CloudVmClusterProperties GetCloudVmClusterProperties() {
            string hostName = "net-sdk-test";
            int cpuCoreCount = 4;
            ResourceIdentifier cloudExadataInfrastructureId = _cloudExadataInfrastructureResource.Data.Id;
            // orpsandbox2
            // List<string> sshPublicKeys = new List<string>() {"ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDN1WFUF/ciSh4GZUBmPlINBDs+zbr4MilqqPYw2jvpbr5Xi5onKUi797eLWApk9xZOzw53j7vQzDvhTIf/jpjhYYolVgu8DWgI9U53UU5HWfC3+LeMEaQ4n1TTo87aQOeMr+eTkWA0DV7Ag69ITRafNN5sD7sNLFPSKGe9YSPFHqQFOigrDet1MtfahOISg8yNcrPUawU5o9RFyTrRQmU1+Eo1CHP0jKpjKKNuE739n2r/l5wugHvYf5f59G5mEyxsb8wDghcIKbd91jD7H1ltXyZ8ubGLMdE9R5gUvJ8g7RqCiZyD7tdBAY+a+z48GL0HCmnY6T/0y+KCtA3lh2gCkycti2RefjRFTeqTFuGGeJaFC/zU6FX1XFFySJnXDdK6895WKvTr/6vj+SrTzgu0cllJbjcPDLKIGBEeGADnfKGx0q4/vaAJMzZrVlJ1POYaTeOYf0DekfPaYpHl4IToenG8u3tU1x3JhEJriOs3ORzApDWlhmnojyePMLTupFU= generated-by-azure"};
            // orpsandbox8
            List<string> sshPublicKeys = new List<string>() {"ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDEZ1wctWAnyIfSvt2rhE7JgV/guNJbDSq7KGo9j6hb+TgPaWhs0DVGcGQnc1LbQShD4Weg5PQogdYaCAjXzxCT/c5ULjlEUUAk9za4q7mnKMW9/poQwvMu+SAmR6u3lSXWv7uj9GuzWtBHykdW9UDWFwMFuj0SrmI4fcpa3nrZ4YcO+kEjxPSODLWwySDQozD4a75grYMA3SA7IMViZHYtpi4Z4UtZxAUIT5vCOJNVkzfrSo3+u1WPXXXhegxkGXuBkb2CRHr5ntWoMXWHI9OqR3ENBVYoq8dy5B4IocRY1En4+Z9X1oMyc6mJsEDRA0ZrkG4CLMN8mXmU9rwU1fxI15ennWr6eBBpsyJYRY7vxTVkV21bI/mrbP+cszXnmqFqC+abQX+EIxVb0cPeSDTzyZos+Rk/NBuiDyRNSFVb7PtLiHyxGhKVYsxtgeL4qhnuz6VYDm9LD75DwoBtyq/vDqy6TInhQruMZHVDc2Iq3QQ/rKbauISMDeDvHe3jz4k= generated-by-azure"};
            ResourceIdentifier vnetId = new ResourceIdentifier(string.Format(VnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName));
            string giVersion = "19.0.0.0";
            ResourceIdentifier subnetId = new ResourceIdentifier(string.Format(SubnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName, DefaultSubnetName));
            string displayName = _vmClusterName;
            return new CloudVmClusterProperties(hostName, cpuCoreCount, cloudExadataInfrastructureId, sshPublicKeys, vnetId, giVersion, subnetId, displayName) {
                LicenseModel = LicenseModel.LicenseIncluded
            };
        }

        private CloudVmClusterPatch GetCloudVmClusterPatch(string tagName, string tagValue) {
            ChangeTrackingDictionary<string, string> tags = new ChangeTrackingDictionary<string, string>
            {
                new KeyValuePair<string, string>(tagName, tagValue)
            };
            CloudVmClusterUpdateProperties vmClusterUpdateProperties = new CloudVmClusterUpdateProperties();
            return new CloudVmClusterPatch(tags, vmClusterUpdateProperties, default);
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
            Console.WriteLine("HERE: TestCloudVMClusterOperations Get");
            Response<CloudVmClusterResource> getVmClusterResponse = await _cloudVMClusterCollection.GetAsync(_vmClusterName);
            CloudVmClusterResource vmClusterResource = getVmClusterResponse.Value;
            Assert.IsNotNull(vmClusterResource);

            // ListByResourceGroup
            Console.WriteLine("HERE: TestCloudVMClusterOperations ListByResourceGroup");
            AsyncPageable<CloudVmClusterResource> vmClusters = _cloudVMClusterCollection.GetAllAsync();
            List<CloudVmClusterResource> vmClusterResult = await vmClusters.ToEnumerableAsync();
            Assert.NotNull(vmClusterResult);
            Assert.IsTrue(vmClusterResult.Count >= 1);

            // ListBySubscription
            Console.WriteLine("HERE: TestCloudVMClusterOperations ListBySubscription");
            vmClusters = OracleDatabaseExtensions.GetCloudVmClustersAsync(DefaultSubscription);
            vmClusterResult = await vmClusters.ToEnumerableAsync();
            Assert.NotNull(vmClusterResult);
            Assert.IsTrue(vmClusterResult.Count >= 1);

            // // Update
            // Console.WriteLine("HERE: TestCloudVMClusterOperations Update");
            // var tagName = Recording.GenerateAssetName("TagName");
            // var tagValue = Recording.GenerateAssetName("TagValue");
            // CloudVmClusterPatch vmClusterParameter = GetCloudVmClusterPatch(tagName, tagValue);
            // var updateVmClusterOperation = await vmClusterResource.UpdateAsync(WaitUntil.Completed, vmClusterParameter);
            // Assert.IsTrue(updateVmClusterOperation.HasCompleted);
            // Assert.IsTrue(updateVmClusterOperation.HasValue);

            // // Get after Update
            // Console.WriteLine("HERE: TestCloudVMClusterOperations Get2");
            // getVmClusterResponse = await _cloudVMClusterCollection.GetAsync(_vmClusterName);
            // vmClusterResource = getVmClusterResponse.Value;
            // Assert.IsNotNull(vmClusterResource);
            // Assert.IsTrue(vmClusterResource.Data.Tags.ContainsKey(tagName));

            // Delete
            Console.WriteLine("HERE: TestCloudVMClusterOperations Delete");
            var deleteVmClusterOperation = await vmClusterResource.DeleteAsync(WaitUntil.Completed);
            await deleteVmClusterOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteVmClusterOperation.HasCompleted);

            DeleteExaInfra();
        }
    }
}