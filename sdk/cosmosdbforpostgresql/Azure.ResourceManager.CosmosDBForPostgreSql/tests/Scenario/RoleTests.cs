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
        private string _rgName;
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        private string _clusterName;
        private CosmosDBForPostgreSqlClusterResource _cluster;
        private ResourceIdentifier _clusterIdentifier;

        public RoleTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("test-rg-");
            _clusterName = SessionRecording.GenerateAssetName("cosmos-pg-net-");
            if (Mode == RecordedTestMode.Playback)
            {
                _resourceGroupIdentifier = ResourceGroupResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), _rgName);
                _clusterIdentifier = CosmosDBForPostgreSqlClusterResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), _rgName, _clusterName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var subscription = await GlobalClient.GetDefaultSubscriptionAsync();
                    var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, _rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                    ResourceGroupResource rg = rgLro.Value;
                    CosmosDBForPostgreSqlClusterCollection cls = rg.GetCosmosDBForPostgreSqlClusters();

                    var data = new CosmosDBForPostgreSqlClusterData(rg.Data.Location)
                    {
                        CoordinatorVCores = 4,
                        IsHAEnabled = false,
                        CoordinatorStorageQuotaInMb = 524288,
                        NodeCount = 0,
                        CoordinatorServerEdition = "GeneralPurpose",
                        IsCoordinatorPublicIPAccessEnabled = true,
                        PostgresqlVersion = "14",
                        CitusVersion = "11.1",
                        AdministratorLoginPassword = "P4ssw@rd1234",
                        IsShardsOnCoordinatorEnabled = true,
                        PreferredPrimaryZone = "1"
                    };

                    var lro = await cls.CreateOrUpdateAsync(WaitUntil.Completed, _clusterName, data);
                    _cluster = lro.Value;
                    _clusterIdentifier = lro.Value.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }
            try
            {
                using (Recording.DisableRecording())
                {
                    await foreach (var cluster in _resourceGroup.GetCosmosDBForPostgreSqlClusters().GetAllAsync())
                    {
                        await cluster.DeleteAsync(WaitUntil.Completed);
                    }
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        [SetUp]
        public async Task Setup()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            _cluster = await _resourceGroup.GetCosmosDBForPostgreSqlClusterAsync(_clusterIdentifier.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGet()
        {
            // Create
            string roleName = Recording.GenerateAssetName("role");
            var data = new CosmosDBForPostgreSqlRoleData("P4ssw@rd");
            CosmosDBForPostgreSqlRoleCollection roles = _cluster.GetCosmosDBForPostgreSqlRoles();
            var lro = await roles.CreateOrUpdateAsync(WaitUntil.Completed, roleName, data);
            CosmosDBForPostgreSqlRoleResource role = lro.Value;
            Assert.AreEqual(roleName, role.Data.Name);

            // Get
            CosmosDBForPostgreSqlRoleResource roleFromGet = await _cluster.GetCosmosDBForPostgreSqlRoleAsync(roleName);
            Assert.AreEqual(roleName, roleFromGet.Data.Name);

            // List
            await foreach (CosmosDBForPostgreSqlRoleResource roleFromList in roles)
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
            var data = new CosmosDBForPostgreSqlRoleData("P4ssw@rd");
            CosmosDBForPostgreSqlRoleCollection roles = _cluster.GetCosmosDBForPostgreSqlRoles();
            var lro = await roles.CreateOrUpdateAsync(WaitUntil.Completed, roleName, data);
            CosmosDBForPostgreSqlRoleResource role = lro.Value;
            Assert.AreEqual(roleName, role.Data.Name);

            // Delete
            CosmosDBForPostgreSqlRoleResource roleFromGet = await _cluster.GetCosmosDBForPostgreSqlRoleAsync(roleName);
            await roleFromGet.DeleteAsync(WaitUntil.Completed);

            List<CosmosDBForPostgreSqlRoleResource> roleList = await _cluster.GetCosmosDBForPostgreSqlRoles().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(roleList);
        }
    }
}
