// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class ServerDnsAliasCrudScenarioTests
    {
        [Fact(Skip = "ReRecord due to CR change")]
        public void TestCrudServerDnsAlias()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create primary and partner servers
                //
                var sourceServer = context.CreateServer(resourceGroup);
                var targetServer = context.CreateServer(resourceGroup, location: TestEnvironmentUtilities.DefaultSecondaryLocationId);

                string serverDnsAliasName = SqlManagementTestUtilities.GenerateName();

                // Create server dns alias pointing to sourceServer
                //
                var serverDnsAlias = sqlClient.ServerDnsAliases.CreateOrUpdate(resourceGroup.Name, sourceServer.Name, serverDnsAliasName);
                ValidateServerDnsAlias(serverDnsAlias, serverDnsAliasName);

                // List server dns aliases on source server and verify
                //
                var serverDnsAliases = sqlClient.ServerDnsAliases.ListByServer(resourceGroup.Name, sourceServer.Name);
                Assert.NotNull(serverDnsAliases);
                Assert.Equal(1, serverDnsAliases.Count());
                Assert.Equal(serverDnsAliasName, serverDnsAliases.Select(a => a.Name).First());

                // Update server to which alias is pointing
                //
                var serverDnsAliasAcquisitonParams = new ServerDnsAliasAcquisition(String.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/dnsAliases/{3}", 
                    sqlClient.SubscriptionId, 
                    resourceGroup.Name, 
                    sourceServer.Name, 
                    serverDnsAliasName));

                sqlClient.ServerDnsAliases.Acquire(resourceGroup.Name, targetServer.Name, serverDnsAliasName, serverDnsAliasAcquisitonParams);

                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.ServerDnsAliases.Get(resourceGroup.Name, sourceServer.Name, serverDnsAliasName));

                // Delete server dns alias and verify it got dropped
                //
                sqlClient.ServerDnsAliases.Delete(resourceGroup.Name, targetServer.Name, serverDnsAliasName);
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.ServerDnsAliases.Get(resourceGroup.Name, targetServer.Name, serverDnsAliasName));

            }
        }

        private void ValidateServerDnsAlias(ServerDnsAlias actual, string name)
        {
            Assert.NotNull(actual);
            Assert.NotNull(actual.Id);
            Assert.Equal(name, actual.Name);
        }
    }
}
