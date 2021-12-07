// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedDatabaseTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public ManagedDatabaseTests(bool isAsync)
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

        [Test]
        [RecordedTest]
        public async Task ManagedDatabaseApiTests()
        {
            // create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string networkSecurityGroupName = Recording.GenerateAssetName("network-security-group-");
            string routeTableName = Recording.GenerateAssetName("route-table-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, networkSecurityGroupName, routeTableName, vnetName, Location.WestUS2, _resourceGroup);

            string databaseName = Recording.GenerateAssetName("mi-database-");
            var collection = managedInstance.GetManagedDatabases();

            // 1.CreateOrUpdata
            ManagedDatabaseData data = new ManagedDatabaseData(Location.WestUS2) { };
            var database = await collection.CreateOrUpdateAsync(databaseName, data);
            Assert.IsNotNull(database.Value.Data);
            Assert.AreEqual(databaseName, database.Value.Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(collection.CheckIfExists(databaseName));
            Assert.IsFalse(collection.CheckIfExists(databaseName + "0"));

            // 3.Get
            var getDatabase = await collection.GetAsync(databaseName);
            Assert.IsNotNull(getDatabase.Value.Data);
            Assert.AreEqual(databaseName, getDatabase.Value.Data.Name);

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(databaseName, list.FirstOrDefault().Data.Name);

            // 5.Delete
            var deleteDatabase = await collection.GetAsync(databaseName);
            await deleteDatabase.Value.DeleteAsync();
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
