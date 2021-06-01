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
    public class ServerCommunicationLinkScenarioTests
    {
        [Fact]
        public void TestCreateGetListCommunicationLinks()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create two servers
                Server server1 = context.CreateServer(resourceGroup);
                Server server2 = context.CreateServer(resourceGroup);

                // Create communication link on server 1
                string linkName = SqlManagementTestUtilities.GenerateName();
                ServerCommunicationLink link = new ServerCommunicationLink()
                {
                    PartnerServer = server2.Name
                };

                sqlClient.ServerCommunicationLinks.CreateOrUpdate(resourceGroup.Name, server1.Name, linkName, link);

                // TODO: Update communication link is not yet supported by the API.
                // When it is, add check here

                // Get Communication Link
                link = sqlClient.ServerCommunicationLinks.Get(resourceGroup.Name, server1.Name, linkName);

                Assert.Equal(linkName, link.Name);
                Assert.Equal(server2.Name, link.PartnerServer);

                // List Communication Link
                IEnumerable<ServerCommunicationLink> links = sqlClient.ServerCommunicationLinks.ListByServer(resourceGroup.Name, server1.Name);

                Assert.Equal(1, links.Count());
                link = links.First();
                Assert.Equal(linkName, link.Name);
                Assert.Equal(server2.Name, link.PartnerServer);
            }
        }

        [Fact]
        public void TestDeleteCommunicationLinks()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create two servers
                Server server1 = context.CreateServer(resourceGroup);
                Server server2 = context.CreateServer(resourceGroup);

                // Create communication link on server 1
                string linkName = SqlManagementTestUtilities.GenerateName();
                ServerCommunicationLink link = new ServerCommunicationLink()
                {
                    PartnerServer = server2.Name
                };

                sqlClient.ServerCommunicationLinks.CreateOrUpdate(resourceGroup.Name, server1.Name, linkName, link);

                // TODO: Update communication link is not yet supported by the API.
                // When it is, add check here

                // List Communication Link, assert there is one
                IEnumerable<ServerCommunicationLink> links = sqlClient.ServerCommunicationLinks.ListByServer(resourceGroup.Name, server1.Name);

                Assert.Equal(1, links.Count());
                link = links.First();
                Assert.Equal(linkName, link.Name);
                Assert.Equal(server2.Name, link.PartnerServer);
                
                // Delete Communication Link
                sqlClient.ServerCommunicationLinks.Delete(resourceGroup.Name, server1.Name, linkName);
                links = sqlClient.ServerCommunicationLinks.ListByServer(resourceGroup.Name, server1.Name);

                // Assert that no links found
                Assert.Equal(0, links.Count());
            }
        }
    }
}
