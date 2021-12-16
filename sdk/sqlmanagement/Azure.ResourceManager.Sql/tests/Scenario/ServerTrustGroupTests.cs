// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ServerTrustGroupTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public ServerTrustGroupTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync();
            }
        }

        private async Task<ServerTrustGroup> CreateServerTrustGroup(string locationName, string serverTrustGroupName)
        {
            // create two ManagedInstanceName
            string managedInstanceName1 = Recording.GenerateAssetName("managed-instance-");
            string managedInstanceName2 = Recording.GenerateAssetName("managed-instance-backup-");
            string networkSecurityGroupName1 = Recording.GenerateAssetName("network-security-group-");
            string networkSecurityGroupName2 = Recording.GenerateAssetName("network-security-group-");
            string routeTableName1 = Recording.GenerateAssetName("route-table-");
            string routeTableName2 = Recording.GenerateAssetName("route-table-");
            string vnetName1 = Recording.GenerateAssetName("vnet-");
            string vnetName2 = Recording.GenerateAssetName("vnet-");
            Task[] tasks = new Task[]
            {
                CreateDefaultManagedInstance(managedInstanceName1, networkSecurityGroupName1, routeTableName1, vnetName1, Location.WestUS2, _resourceGroup),
                CreateDefaultManagedInstance(managedInstanceName2, networkSecurityGroupName2, routeTableName2, vnetName2, Location.WestUS2, _resourceGroup),
            };
            Task.WaitAll(tasks);
            string primaryManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(managedInstanceName1)).Value.Data.Id.ToString();
            string backupManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(managedInstanceName2)).Value.Data.Id.ToString();

            // create ServerTrustGroup
            ServerTrustGroupData data = new ServerTrustGroupData()
            {
                GroupMembers =
                {
                    new ServerInfo(primaryManagedInstanceId),
                    new ServerInfo(backupManagedInstanceId),
                },
                TrustScopes = { ServerTrustGroupPropertiesTrustScopesItem.GlobalTransactions},
            };
            var serverTrustGroup = await _resourceGroup.GetServerTrustGroups().CreateOrUpdateAsync(locationName, serverTrustGroupName, data);
            return serverTrustGroup.Value;
        }

        [Test]
        [Ignore("not record yet")]
        [RecordedTest]
        public async Task ServerTrustGroupsApiTests()
        {
            // 1.CreateOrUpdate
            string locationName = Location.WestUS2.ToString();
            string serverTrustGroupName = Recording.GenerateAssetName("trust-group-");
            var serverTrustGroup = await CreateServerTrustGroup(locationName, serverTrustGroupName);
            Assert.IsNotNull(serverTrustGroup.Data);
            Assert.AreEqual(serverTrustGroupName, serverTrustGroup.Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(_resourceGroup.GetServerTrustGroups().CheckIfExists(locationName, serverTrustGroupName));

            // 3.Get
            var getServerTrustGroup = await _resourceGroup.GetServerTrustGroups().GetAsync(locationName, serverTrustGroupName);
            Assert.IsNotNull(getServerTrustGroup.Value.Data);
            Assert.AreEqual(serverTrustGroupName, getServerTrustGroup.Value.Data.Name);

            // 4.GetAll
            var list = await _resourceGroup.GetServerTrustGroups().GetAllAsync(locationName).ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // 5.Delete
            //var deleteServerTrustGroup = await _resourceGroup.GetServerTrustGroups().GetAsync(locationName, serverTrustGroupName);
            //await deleteServerTrustGroup.Value.DeleteAsync();
            //list = await _resourceGroup.GetServerTrustGroups().GetAllAsync(locationName).ToEnumerableAsync();
        }

        [Test]
        [Ignore("not record yet")]
        [RecordedTest]
        public async Task Delete()
        {
            string locationName = Location.WestUS2.ToString();
            string serverTrustGroupName = Recording.GenerateAssetName("trust-group-");
            var serverTrustGroup = await CreateServerTrustGroup(locationName, serverTrustGroupName);
            Assert.IsNotNull(serverTrustGroup.Data);

            var list = await _resourceGroup.GetServerTrustGroups().GetAllAsync(locationName).ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            var deleteServerTrustGroup = await _resourceGroup.GetServerTrustGroups().GetAsync(locationName, serverTrustGroupName);
            await deleteServerTrustGroup.Value.DeleteAsync();
            list = await _resourceGroup.GetServerTrustGroups().GetAllAsync(locationName).ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
