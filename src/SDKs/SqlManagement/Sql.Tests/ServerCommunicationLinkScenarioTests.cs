// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class ServerCommunicationLinkScenarioTests
    {
        [Fact]
        public void TestCreateUpdateGetDropServer()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewResourceGroup(suiteName, "TestCreateUpdateGetDropServer", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                string server1Name = SqlManagementTestUtilities.GenerateName(testPrefix);
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create two servers
                var server1 = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, server1Name, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Tags = tags,
                    Location = SqlManagementTestUtilities.DefaultLocationId,
                });
                SqlManagementTestUtilities.ValidateServer(server1, server1Name, login, version12, tags, SqlManagementTestUtilities.DefaultLocationId);
                
                string server2Name = SqlManagementTestUtilities.GenerateName(testPrefix);
                var server2 = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, server2Name, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Tags = tags,
                    Location = SqlManagementTestUtilities.DefaultLocationId,
                });
                SqlManagementTestUtilities.ValidateServer(server2, server2Name, login, version12, tags, SqlManagementTestUtilities.DefaultLocationId);

                // Create communication link on server 1
                string linkName = SqlManagementTestUtilities.GenerateName(testPrefix);
                ServerCommunicationLink link = new ServerCommunicationLink()
                {
                    PartnerServer = server2Name
                };

                sqlClient.ServerCommunicationLinks.CreateOrUpdate(resourceGroup.Name, server1Name, linkName, link);

                // TODO: Update communication link is not yet supported by the API.
                // When it is, add check here

                // Get Communication Link
                link = sqlClient.ServerCommunicationLinks.Get(resourceGroup.Name, server1Name, linkName);

                Assert.Equal(linkName, link.Name);
                Assert.Equal(server2Name, link.PartnerServer);

                // List Communication Link
                IEnumerable<ServerCommunicationLink> links = sqlClient.ServerCommunicationLinks.ListByServer(resourceGroup.Name, server1Name);

                Assert.Equal(1, links.Count());
                link = links.First();
                Assert.Equal(linkName, link.Name);
                Assert.Equal(server2Name, link.PartnerServer);
            });
        }
    }
}
