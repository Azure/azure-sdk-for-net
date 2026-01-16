// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class ManagedDatabaseTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public ManagedDatabaseTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            var lro = await client.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroup = lro.Value;
        }

        [Test]
        [RecordedTest]
        public async Task ManagedDatabaseApiTests()
        {
            // create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            string databaseName = Recording.GenerateAssetName("mi-database-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            var collection = managedInstance.GetManagedDatabases();

            // 1.CreateOrUpdata
            ManagedDatabaseData data = new ManagedDatabaseData(AzureLocation.WestUS2) { };
            var database = await collection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, data);
            Assert.That(database.Value.Data, Is.Not.Null);
            Assert.That(database.Value.Data.Name, Is.EqualTo(databaseName));

            // 2.CheckIfExist
            Assert.That((bool)await collection.ExistsAsync(databaseName), Is.True);
            Assert.That((bool)await collection.ExistsAsync(databaseName + "0"), Is.False);

            // 3.Get
            var getDatabase = await collection.GetAsync(databaseName);
            Assert.That(getDatabase.Value.Data, Is.Not.Null);
            Assert.That(getDatabase.Value.Data.Name, Is.EqualTo(databaseName));

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.FirstOrDefault().Data.Name, Is.EqualTo(databaseName));

            // 5.Delete
            var deleteDatabase = await collection.GetAsync(databaseName);
            await deleteDatabase.Value.DeleteAsync(WaitUntil.Completed);
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Empty);
        }
    }
}
