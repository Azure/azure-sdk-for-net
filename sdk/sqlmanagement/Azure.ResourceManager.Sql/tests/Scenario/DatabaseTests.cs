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
                AdministratorLoginPassword = "Xx123456123456*",
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

        [TearDown]
        public async Task TearDown()
        {
            var serverList = await _resourceGroup.GetServers().GetAllAsync().ToEnumerableAsync();
            foreach (var item in serverList)
            {
                await item.DeleteAsync();
            }
        }

        //private async Task<Database> CreateOrUpdateDatabase(string databaseName)
        //{
        //    _resourceGroup.GetResourceGroupLocationLongTermRetentionServerLongTermRetentionDatabaseLongTermRetentionBackups();
        //    throw new Exception();
        //}

        //[Test]
        //[RecordedTest]
        //public async Task CheckIfExist()
        //{
        //    string serverName = Recording.GenerateAssetName("server-");
        //    await CreateOrUpdateServer(serverName);
        //    Assert.AreEqual(true, _resourceGroup.GetServers().CheckIfExists(serverName).Value);
        //}

        //[Test]
        //[RecordedTest]
        //public async Task CreateOrUpdate()
        //{
        //    string databaseName = Recording.GenerateAssetName("database-");
        //    var database =await CreateOrUpdateDatabase(databaseName);
        //}
    }
}
