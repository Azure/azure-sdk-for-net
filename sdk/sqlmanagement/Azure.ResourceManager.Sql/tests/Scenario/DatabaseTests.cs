// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class DatabaseTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        private string _serverName;
        private Server _server;

        public DatabaseTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;

            // create server
            _serverName = Recording.GenerateAssetName("server-");
            ServerData data = new ServerData(Location.WestUS2)
            {
                AdministratorLogin = "Admin-" + _serverName,
                AdministratorLoginPassword = CreateGeneralPassword(),
            };
            var serverLro = await _resourceGroup.GetServers().CreateOrUpdateAsync(_serverName, data);
            _server = serverLro.Value;
            StopSessionRecording();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseApiTests()
        {
            // create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, Location.WestUS2, _resourceGroup);
            var collection = managedInstance.GetManagedDatabases();

            // 1.CreateOrUpdata
            string databaseName = Recording.GenerateAssetName("mi-database-");
            ManagedDatabaseData data = new ManagedDatabaseData(Location.WestUS2) { };
            var database = await collection.CreateOrUpdateAsync(databaseName, data);
            Assert.IsNotNull(database.Value.Data);
            Assert.AreEqual(databaseName, database.Value.Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(collection.CheckIfExists(databaseName));
            Assert.IsFalse(collection.CheckIfExists(databaseName + "0"));

            // 3.Get
            var getDatabase =await collection.GetAsync(databaseName);
            Assert.IsNotNull(getDatabase.Value.Data);
            Assert.AreEqual(getDatabase, database.Value.Data.Name);

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1,list.Count);
            Assert.AreEqual(getDatabase, list.FirstOrDefault().Data.Name);

            // 5.Delete
            var deleteDatabase = await collection.GetAsync(databaseName);
            await deleteDatabase.Value.DeleteAsync();
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
