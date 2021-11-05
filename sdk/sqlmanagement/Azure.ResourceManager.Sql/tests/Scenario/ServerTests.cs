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
    public class ServerTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public ServerTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
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

        private async Task<Server> CreateOrUpdateServer(string serverName)
        {
            ServerData data = new ServerData(Location.WestUS2)
            {
                AdministratorLogin = "Admin-" + serverName,
                AdministratorLoginPassword = "Xx123456123456*",
            };
            var server = await _resourceGroup.GetServers().CreateOrUpdateAsync(serverName, data);
            return server.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            string serverName = Recording.GenerateAssetName("server-");
            await CreateOrUpdateServer(serverName);
            Assert.AreEqual(true, _resourceGroup.GetServers().CheckIfExists(serverName).Value);
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string serverName = Recording.GenerateAssetName("server-");
            var server = await CreateOrUpdateServer(serverName);
            Assert.IsNotNull(server.Data);
            Assert.AreEqual(serverName, server.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string serverName = Recording.GenerateAssetName("server-");
            await CreateOrUpdateServer(serverName);
            var server = await _resourceGroup.GetServers().GetAsync(serverName);
            Assert.IsNotNull(server.Value.Data);
            Assert.AreEqual(serverName, server.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string serverName = Recording.GenerateAssetName("server-");
            await CreateOrUpdateServer(serverName);
            var serverList = await _resourceGroup.GetServers().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(serverList);
            Assert.AreEqual(1,serverList.Count);
            Assert.AreEqual(serverName,serverList[0].Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string serverName = Recording.GenerateAssetName("server-");
            await CreateOrUpdateServer(serverName);
            var serverList = await _resourceGroup.GetServers().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, serverList.Count);

            await serverList[0].DeleteAsync();
            serverList = await _resourceGroup.GetServers().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, serverList.Count);
        }
    }
}
