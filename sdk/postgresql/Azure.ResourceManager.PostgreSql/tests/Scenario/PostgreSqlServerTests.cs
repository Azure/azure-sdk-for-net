// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PostgreSql;
using Azure.ResourceManager.PostgreSql.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PostgreSql.Tests
{
    public class PostgreSqlServerTests: PostgreSqlManagementTestBase
    {
        public PostgreSqlServerTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetList()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "pgrg", AzureLocation.WestUS);
            PostgreSqlServerCollection serverCollection = rg.GetPostgreSqlServers();
            string serverName = Recording.GenerateAssetName("pgserver");
            var content = new PostgreSqlServerCreateOrUpdateContent(
                new PostgreSqlServerPropertiesForDefaultCreate(administratorLogin: "testUser", administratorLoginPassword: "testPassword1!"),
                rg.Data.Location)
                {
                    Sku = new PostgreSqlSku("B_Gen5_1")
                };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, content);
            PostgreSqlServerResource server = lro.Value;
            Assert.That(server.Data.Name, Is.EqualTo(serverName));
            // Get
            PostgreSqlServerResource serverFromGet = await serverCollection.GetAsync(serverName);
            Assert.That(serverFromGet.Data.Name, Is.EqualTo(serverName));
            // List
            await foreach (PostgreSqlServerResource serverFromList in serverCollection)
            {
                Assert.That(serverFromList.Data.Name, Is.EqualTo(serverName));
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateUpdateGetDelete()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "pgrg", AzureLocation.WestUS);
            PostgreSqlServerCollection serverCollection = rg.GetPostgreSqlServers();
            string serverName = Recording.GenerateAssetName("pgserver");
            var content = new PostgreSqlServerCreateOrUpdateContent(
                new PostgreSqlServerPropertiesForDefaultCreate(administratorLogin: "testUser", administratorLoginPassword: "testPassword1!"),
                rg.Data.Location)
                {
                    Sku = new PostgreSqlSku("B_Gen5_1")
                };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, content);
            PostgreSqlServerResource server = lro.Value;
            Assert.That(server.Data.Name, Is.EqualTo(serverName));
            // Update
            lro = await server.UpdateAsync(WaitUntil.Completed, new PostgreSqlServerPatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            });
            PostgreSqlServerResource serverFromUpdate = lro.Value;
            Assert.That(serverFromUpdate.Data.Name, Is.EqualTo(serverName));
            Assert.That(serverFromUpdate.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            // Get
            PostgreSqlServerResource serverFromGet = await serverFromUpdate.GetAsync();
            Assert.That(serverFromGet.Data.Name, Is.EqualTo(serverName));
            // Delete
            await serverFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
