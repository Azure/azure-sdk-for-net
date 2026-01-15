// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MySql;
using Azure.ResourceManager.MySql.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MySql.Tests
{
    public class MySqlServerTests: MySqlManagementTestBase
    {
        public MySqlServerTests(bool isAsync)
            : base(isAsync)//,RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("The server type 'Azure Database for MySQL Single Server' has been deactivated")]
        public async Task CreateGetList()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "mysqlrg", AzureLocation.WestUS);
            MySqlServerCollection serverCollection = rg.GetMySqlServers();
            string serverName = Recording.GenerateAssetName("mysqlserver");
            var content = new MySqlServerCreateOrUpdateContent(
                new MySqlServerPropertiesForDefaultCreate(administratorLogin: "testUser", administratorLoginPassword: "testPassword1!"),
                rg.Data.Location)
                {
                    Sku = new MySqlSku("B_Gen5_1")
                };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, content);
            MySqlServerResource server = lro.Value;
            Assert.That(server.Data.Name, Is.EqualTo(serverName));
            // Get
            MySqlServerResource serverFromGet = await serverCollection.GetAsync(serverName);
            Assert.That(serverFromGet.Data.Name, Is.EqualTo(serverName));
            // List
            await foreach (MySqlServerResource serverFromList in serverCollection)
            {
                Assert.That(serverFromList.Data.Name, Is.EqualTo(serverName));
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("The server type 'Azure Database for MySQL Single Server' has been deactivated")]
        public async Task CreateUpdateGetDelete()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "mysqlrg", AzureLocation.WestUS);
            MySqlServerCollection serverCollection = rg.GetMySqlServers();
            string serverName = Recording.GenerateAssetName("mysqlserver");
            var content = new MySqlServerCreateOrUpdateContent(
                new MySqlServerPropertiesForDefaultCreate(administratorLogin: "testUser", administratorLoginPassword: "testPassword1!"),
                rg.Data.Location)
                {
                    Sku = new MySqlSku("B_Gen5_1")
                };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, content);
            MySqlServerResource server = lro.Value;
            Assert.That(server.Data.Name, Is.EqualTo(serverName));
            // Update
            lro = await server.UpdateAsync(WaitUntil.Completed, new MySqlServerPatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            });
            MySqlServerResource serverFromUpdate = lro.Value;
            Assert.That(serverFromUpdate.Data.Name, Is.EqualTo(serverName));
            Assert.That(serverFromUpdate.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            // Get
            MySqlServerResource serverFromGet = await serverFromUpdate.GetAsync();
            Assert.That(serverFromGet.Data.Name, Is.EqualTo(serverName));
            // Delete
            await serverFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
