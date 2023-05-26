// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDBForPostgreSql.Tests
{
    public class RoleTests : CosmosDBForPostgreSqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        private ResourceIdentifier _resourceGroupIdentifier;
        private ClusterResource _cluster;
        private string _rgName;
        private ResourceIdentifier _clusterIdentifier;

        public RoleTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("test-rg-");
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();

            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, _rgName, new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;

            ClusterCollection cls =  rg.GetClusters();

            string clusterName = SessionRecording.GenerateAssetName("cosmospgnet-");
            var data = new ClusterData(rg.Data.Location)
            {
                CoordinatorVCores = 4,
                EnableHa = false,
                CoordinatorStorageQuotaInMb = 524288,
                NodeCount = 0,
                CoordinatorServerEdition = "GeneralPurpose",
                CoordinatorEnablePublicIPAccess = true,
                PostgresqlVersion = "14",
                CitusVersion = "11.1",
                AdministratorLoginPassword = "P4ssw@rd1234",
                EnableShardsOnCoordinator = true,
                PreferredPrimaryZone = "1"
            };

            var lro = await cls.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            _cluster = lro.Value;
            _clusterIdentifier = lro.Value.Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task Setup()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            _cluster = await _resourceGroup.GetClusterAsync(_clusterIdentifier.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGet()
        {
            // Create
            string roleName = Recording.GenerateAssetName("role");
            var data = new RoleData("P4ssw@rd");
            RoleCollection roles = _cluster.GetRoles();
            var lro = await roles.CreateOrUpdateAsync(WaitUntil.Completed, roleName, data);
            RoleResource role = lro.Value;
            Assert.AreEqual(roleName, role.Data.Name);

            // Get
            RoleResource roleFromGet = await _cluster.GetRoleAsync(roleName);
            Assert.AreEqual(roleName, roleFromGet.Data.Name);

            // List
            await foreach (RoleResource roleFromList in roles)
            {
                Assert.AreEqual(roleName, roleFromList.Data.Name);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            // Create
            string roleName = Recording.GenerateAssetName("role");
            var data = new RoleData("P4ssw@rd");
            RoleCollection roles = _cluster.GetRoles();
            var lro = await roles.CreateOrUpdateAsync(WaitUntil.Completed, roleName, data);
            RoleResource role = lro.Value;
            Assert.AreEqual(roleName, role.Data.Name);

            // Delete
            RoleResource roleFromGet = await _cluster.GetRoleAsync(roleName);
            await roleFromGet.DeleteAsync(WaitUntil.Completed);

            List<RoleResource> roleList = await _cluster.GetRoles().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(roleList);
        }
    }
}
