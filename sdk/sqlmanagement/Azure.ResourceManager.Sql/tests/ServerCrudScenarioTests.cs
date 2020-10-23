// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Sql;
using Azure.ResourceManager.Sql.Models;
using Azure.ResourceManager.Sql.Tests;
using NUnit.Framework;

namespace Sql.Tests
{
    public class ServerCrudScenarioTests : SqlManagementClientBase
    {
        protected ServerCrudScenarioTests(bool isAsync)
            : base(isAsync)
        {
            InitializeBase();
        }

        [Test]
        public async Task TestCreateUpdateGetDropServer()
        {
                var resourceGroup = context.CreateResourceGroup();
                var sqlClient = context.GetClient<SqlManagementClient>();

                string serverNameV12 = SqlManagementTestUtilities.GenerateName();
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create server
                var server1 = await (await sqlClient.Servers.StartCreateOrUpdateAsync(resourceGroup.Name, serverNameV12, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Tags = {
                        { "tagKey1", "TagValue1" }
                    },
                    Location = TestEnvironmentUtilities.DefaultLocationId,
                })).WaitForCompletionAsync();
                SqlManagementTestUtilities.ValidateServer(server1, serverNameV12, login, version12, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Create second server
                string server2 = SqlManagementTestUtilities.GenerateName();
                var v2Server = await (await sqlClient.Servers.StartCreateOrUpdateAsync(resourceGroup.Name, server2, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Tags = tags,
                    Location = TestEnvironmentUtilities.DefaultLocationId,
                })).WaitForCompletionAsync();
                SqlManagementTestUtilities.ValidateServer(v2Server, server2, login, version12, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Get first server
                var getServer1 = sqlClient.Servers.Get(resourceGroup.Name, serverNameV12);
                SqlManagementTestUtilities.ValidateServer(getServer1, serverNameV12, login, version12, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Get second server
                var getServer2 = sqlClient.Servers.Get(resourceGroup.Name, server2);
                SqlManagementTestUtilities.ValidateServer(getServer2, server2, login, version12, tags, TestEnvironmentUtilities.DefaultLocationId);

                var listServers = sqlClient.Servers.ListByResourceGroup(resourceGroup.Name);
                Assert.AreEqual(2, listServers.Count());

                // Update first server
                Dictionary<string, string> newTags = new Dictionary<string, string>()
                    {
                        { "asdf", "zxcv" }
                    };
                var updateServer1 = sqlClient.Servers.Update(resourceGroup.Name, serverNameV12, new ServerUpdate { Tags = newTags });
                SqlManagementTestUtilities.ValidateServer(updateServer1, serverNameV12, login, version12, newTags, TestEnvironmentUtilities.DefaultLocationId);

                // Drop server, update count
                await sqlClient.Servers.StartDeleteAsync(resourceGroup.Name, serverNameV12);

                var listServers2 = sqlClient.Servers.ListByResourceGroup(resourceGroup.Name);
                Assert.AreEqual(1, listServers2.Count());
            }
        }

        [Test]
        public async Task TestServerPublicNetworkAccess()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                var resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                string location = TestEnvironmentUtilities.DefaultEuapPrimaryLocationId;
                string enabled = "Enabled";
                string disabled = "Disabled";

                string serverName1= SqlManagementTestUtilities.GenerateName();
                string serverName2 = SqlManagementTestUtilities.GenerateName();
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create server with PublicNetworkAccess disabled and verify its been disabled
                var server1 = await (await sqlClient.Servers.StartCreateOrUpdateAsync(resourceGroup.Name, serverName1, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Tags = tags,
                    Location = location,
                    PublicNetworkAccess = disabled
                })).WaitForCompletionAsync();
                SqlManagementTestUtilities.ValidateServer(server1, serverName1, login, version12, tags, location, disabled);

                // Get server and verify that server is disabled
                server1 = sqlClient.Servers.Get(resourceGroup.Name, serverName1);
                SqlManagementTestUtilities.ValidateServer(server1, serverName1, login, version12, tags, location, disabled);

                // Create server with PublicNetworkAccess enabled and verify its been enabled
                server1 = await (await sqlClient.Servers.StartCreateOrUpdateAsync(resourceGroup.Name, serverName1, new Server()
                {
                    Location = location,
                    PublicNetworkAccess = enabled
                })).WaitForCompletionAsync();
                SqlManagementTestUtilities.ValidateServer(server1, serverName1, login, version12, tags, location, enabled); ;

                // Create second server with no PublicNetworkAccess verify it defaults to enabled
                var server2 = await (await sqlClient.Servers.StartCreateOrUpdateAsync(resourceGroup.Name, serverName2, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Tags = tags,
                    Location = location,
                })).WaitForCompletionAsync();
                SqlManagementTestUtilities.ValidateServer(server2, serverName2, login, version12, tags, location, enabled);

                // Get servers and verify all are enabled
                var serverList = sqlClient.Servers.List();
                foreach (var server in serverList)
                {
                    if (server.Name.Equals(serverName1) || server.Name.Equals(serverName2))
                    {
                        Assert.AreEqual(enabled, server.PublicNetworkAccess);
                    }
                }

                // Drop servers
                await sqlClient.Servers.StartDeleteAsync(resourceGroup.Name, serverName1);
                await sqlClient.Servers.StartDeleteAsync(resourceGroup.Name, serverName2);
            }
        }

        [Test]
        public async Task TestServerMinimalTlsVersion()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                var resourceGroup = context.CreateResourceGroup();
                var sqlClient = context.GetClient<SqlManagementClient>();
                string location = TestEnvironmentUtilities.DefaultEuapPrimaryLocationId;
                string minTlsVersion1_1 = "1.1";
                string minTlsVersion1_2 = "1.2";

                string serverName = SqlManagementTestUtilities.GenerateName();
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create a server with TLS version enforcement set to > 1.1
                var vm = new Server(location)
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Location = location,
                    MinimalTlsVersion = minTlsVersion1_1
                };
                vm.Tags.Clear();
                // set tags

                var server = await (await sqlClient.Servers.StartCreateOrUpdateAsync(resourceGroup.Name, serverName, vm)).WaitForCompletionAsync();
                SqlManagementTestUtilities.ValidateServer(server, serverName, login, version12, tags, location, minimalTlsVersion: minTlsVersion1_1);

                // Get server and verify that minimal TLS version is correct
                server = sqlClient.Servers.Get(resourceGroup.Name, serverName);
                SqlManagementTestUtilities.ValidateServer(server, serverName, login, version12, tags, location, minimalTlsVersion: minTlsVersion1_1);

                // Update TLS version enforcement on the server to > 1.2
                server = await (await sqlClient.Servers.StartCreateOrUpdateAsync(resourceGroup.Name, serverName, new Server(location)
                {
                    Location = location,
                    MinimalTlsVersion = minTlsVersion1_2
                })).WaitForCompletionAsync();
                SqlManagementTestUtilities.ValidateServer(server, serverName, login, version12, tags, location, minimalTlsVersion: minTlsVersion1_2); ;

                // Drop the server
                await sqlClient.Servers.StartDeleteAsync(resourceGroup.Name, serverName);
            }
        }
    }
}
