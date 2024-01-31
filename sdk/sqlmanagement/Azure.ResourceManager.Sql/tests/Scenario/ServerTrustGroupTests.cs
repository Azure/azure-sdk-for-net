// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class ServerTrustGroupTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public ServerTrustGroupTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<SqlServerTrustGroupResource> CreateServerTrustGroup(string locationName, string serverTrustGroupName)
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
                CreateDefaultManagedInstance(managedInstanceName1, vnetName1, AzureLocation.WestUS2, _resourceGroup),
                CreateDefaultManagedInstance(managedInstanceName2, vnetName2, AzureLocation.WestUS2, _resourceGroup),
            };
            Task.WaitAll(tasks);
            ResourceIdentifier primaryManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(managedInstanceName1)).Value.Data.Id;
            ResourceIdentifier backupManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(managedInstanceName2)).Value.Data.Id;

            // create ServerTrustGroup
            SqlServerTrustGroupData data = new SqlServerTrustGroupData()
            {
                GroupMembers =
                {
                    new ServerTrustGroupServerInfo(primaryManagedInstanceId),
                    new ServerTrustGroupServerInfo(backupManagedInstanceId),
                },
                TrustScopes = { ServerTrustGroupPropertiesTrustScopesItem.GlobalTransactions},
            };
            var serverTrustGroup = await _resourceGroup.GetSqlServerTrustGroups(locationName).CreateOrUpdateAsync(WaitUntil.Completed, serverTrustGroupName, data);
            return serverTrustGroup.Value;
        }

        [Test]
        [Ignore("not record yet")]
        [RecordedTest]
        public async Task ServerTrustGroupsApiTests()
        {
            // 1.CreateOrUpdate
            string locationName = AzureLocation.WestUS2.ToString();
            string serverTrustGroupName = Recording.GenerateAssetName("trust-group-");
            var serverTrustGroup = await CreateServerTrustGroup(locationName, serverTrustGroupName);
            Assert.IsNotNull(serverTrustGroup.Data);
            Assert.AreEqual(serverTrustGroupName, serverTrustGroup.Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(_resourceGroup.GetSqlServerTrustGroups(locationName).Exists(serverTrustGroupName));

            // 3.Get
            var getServerTrustGroup = await _resourceGroup.GetSqlServerTrustGroups(locationName).GetAsync(serverTrustGroupName);
            Assert.IsNotNull(getServerTrustGroup.Value.Data);
            Assert.AreEqual(serverTrustGroupName, getServerTrustGroup.Value.Data.Name);

            // 4.GetAll
            var list = await _resourceGroup.GetSqlServerTrustGroups(locationName).GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // 5.Delete
            //var deleteServerTrustGroup = await _resourceGroup.GetSqlServerTrustGroups().GetAsync(locationName, serverTrustGroupName);
            //await deleteServerTrustGroup.Value.DeleteAsync();
            //list = await _resourceGroup.GetSqlServerTrustGroups().GetAllAsync(locationName).ToEnumerableAsync();
        }

        [Test]
        [Ignore("not record yet")]
        [RecordedTest]
        public async Task Delete()
        {
            string locationName = AzureLocation.WestUS2.ToString();
            string serverTrustGroupName = Recording.GenerateAssetName("trust-group-");
            var serverTrustGroup = await CreateServerTrustGroup(locationName, serverTrustGroupName);
            Assert.IsNotNull(serverTrustGroup.Data);

            var list = await _resourceGroup.GetSqlServerTrustGroups(locationName).GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            var deleteServerTrustGroup = await _resourceGroup.GetSqlServerTrustGroups(locationName).GetAsync(serverTrustGroupName);
            await deleteServerTrustGroup.Value.DeleteAsync(WaitUntil.Completed);
            list = await _resourceGroup.GetSqlServerTrustGroups(locationName).GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
