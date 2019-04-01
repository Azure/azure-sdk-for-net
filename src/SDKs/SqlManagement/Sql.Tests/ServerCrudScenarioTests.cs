// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class ServerCrudScenarioTests
    {
        [Fact]
        public void TestCreateUpdateGetDropServer()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                string serverNameV12 = SqlManagementTestUtilities.GenerateName();
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create server
                var server1 = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverNameV12, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Tags = tags,
                    Location = TestEnvironmentUtilities.DefaultLocationId,
                });
                SqlManagementTestUtilities.ValidateServer(server1, serverNameV12, login, version12, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Create second server
                string server2 = SqlManagementTestUtilities.GenerateName();
                var v2Server = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, server2, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Tags = tags,
                    Location = TestEnvironmentUtilities.DefaultLocationId,
                });
                SqlManagementTestUtilities.ValidateServer(v2Server, server2, login, version12, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Get first server
                var getServer1 = sqlClient.Servers.Get(resourceGroup.Name, serverNameV12);
                SqlManagementTestUtilities.ValidateServer(getServer1, serverNameV12, login, version12, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Get second server
                var getServer2 = sqlClient.Servers.Get(resourceGroup.Name, server2);
                SqlManagementTestUtilities.ValidateServer(getServer2, server2, login, version12, tags, TestEnvironmentUtilities.DefaultLocationId);

                var listServers = sqlClient.Servers.ListByResourceGroup(resourceGroup.Name);
                Assert.Equal(2, listServers.Count());

                // Update first server
                Dictionary<string, string> newTags = new Dictionary<string, string>()
                    {
                        { "asdf", "zxcv" }
                    };
                var updateServer1 = sqlClient.Servers.Update(resourceGroup.Name, serverNameV12, new ServerUpdate { Tags = newTags });
                SqlManagementTestUtilities.ValidateServer(updateServer1, serverNameV12, login, version12, newTags, TestEnvironmentUtilities.DefaultLocationId);

                // Drop server, update count
                sqlClient.Servers.Delete(resourceGroup.Name, serverNameV12);

                var listServers2 = sqlClient.Servers.ListByResourceGroup(resourceGroup.Name);
                Assert.Equal(1, listServers2.Count());
            }
        }
    }
}
