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
            Assert.AreEqual(serverName, server.Data.Name);
            // Get
            PostgreSqlServerResource serverFromGet = await serverCollection.GetAsync(serverName);
            Assert.AreEqual(serverName, serverFromGet.Data.Name);
            // List
            await foreach (PostgreSqlServerResource serverFromList in serverCollection)
            {
                Assert.AreEqual(serverName, serverFromList.Data.Name);
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
            Assert.AreEqual(serverName, server.Data.Name);
            // Update
            lro = await server.UpdateAsync(WaitUntil.Completed, new PostgreSqlServerPatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            });
            PostgreSqlServerResource serverFromUpdate = lro.Value;
            Assert.AreEqual(serverName, serverFromUpdate.Data.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, serverFromUpdate.Data.Identity.ManagedServiceIdentityType);
            // Get
            PostgreSqlServerResource serverFromGet = await serverFromUpdate.GetAsync();
            Assert.AreEqual(serverName, serverFromGet.Data.Name);
            // Delete
            await serverFromGet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
