// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Rest.Azure;
using Xunit;

namespace Sql.Tests
{
    public class SyncAgentScenarioTests
    {
        [Fact]
        public void SyncAgentCRUDTest()
        {
            string testPrefix = "syncagentcrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Server server = context.CreateServer(resourceGroup);

                // Create database
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                Database db = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(db);
                Assert.NotNull(db.Id);

                // Create sync agent
                string agentName = SqlManagementTestUtilities.GenerateName("syncagentcrudtest");
                SyncAgent createAgent = sqlClient.SyncAgents.CreateOrUpdate(resourceGroup.Name, server.Name, agentName, new SyncAgent
                {
                    SyncDatabaseId = db.Id
                });
                Assert.NotNull(createAgent);

                // Get sync agent
                SyncAgent getAgent = sqlClient.SyncAgents.Get(resourceGroup.Name, server.Name, agentName);
                Assert.NotNull(getAgent);

                // List sync agent
                IPage<SyncAgent> listAgents = sqlClient.SyncAgents.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(1, listAgents.Count());
                Assert.Equal(agentName, listAgents.Single().Name);

                // Generate key
                SyncAgentKeyProperties agentKey = sqlClient.SyncAgents.GenerateKey(resourceGroup.Name, server.Name, agentName);
                Assert.NotNull(agentKey);
                Assert.NotNull(agentKey.SyncAgentKey);

                // Regenerate key
                SyncAgentKeyProperties agentKey2 = sqlClient.SyncAgents.GenerateKey(resourceGroup.Name, server.Name, agentName);
                Assert.NotNull(agentKey2);
                Assert.NotNull(agentKey2.SyncAgentKey);

                // Get linked databases
                IPage<SyncAgentLinkedDatabase> linkedDatabases = sqlClient.SyncAgents.ListLinkedDatabases(resourceGroup.Name, server.Name, agentName);
                Assert.NotNull(linkedDatabases);
                Assert.Equal(0, linkedDatabases.Count());

                // Delete the sync agent
                sqlClient.SyncAgents.Delete(resourceGroup.Name, server.Name, agentName);
            }
        }
    }
}
