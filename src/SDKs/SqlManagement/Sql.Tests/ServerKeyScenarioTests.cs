// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Linq;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Sql.Tests
{
    public class ServerKeyScenarioTests
    {
        [Fact]
        public void TestCreateUpdateDropServerKey()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = sqlClient.Servers.CreateOrUpdate(
                    resourceGroup.Name,
                    serverName: SqlManagementTestUtilities.GenerateName(),
                    parameters: new Server
                    {
                        AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                        AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                        Location = resourceGroup.Location,
                        Identity = new ResourceIdentity()
                        {
                            Type = IdentityType.SystemAssigned
                        }
                    });

                var keyBundle = SqlManagementTestUtilities.CreateKeyVaultKeyWithServerAccess(context, resourceGroup, server);

                // Create server key
                string serverKeyName = SqlManagementTestUtilities.GetServerKeyNameFromKeyBundle(keyBundle);
                string serverKeyUri = keyBundle.Key.Kid;
                var serverKey = sqlClient.ServerKeys.CreateOrUpdate(resourceGroup.Name, server.Name, serverKeyName, new ServerKey()
                {
                    ServerKeyType = "AzureKeyVault",
                    Uri = serverKeyUri
                });
                SqlManagementTestUtilities.ValidateServerKey(serverKey, serverKeyName, "AzureKeyVault", serverKeyUri);

                // Validate key exists by getting key
                var key1 = sqlClient.ServerKeys.Get(resourceGroup.Name, server.Name, serverKeyName);
                SqlManagementTestUtilities.ValidateServerKey(key1, serverKeyName, "AzureKeyVault", serverKeyUri);

                // Validate key exists by listing keys
                var keyList = sqlClient.ServerKeys.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(2, keyList.Count());

                //TODO: Temporarily disabling this since delete operation is affected by a production bug.
                //// Delete key
                //sqlClient.ServerKeys.Delete(resourceGroup.Name, server.Name, serverKeyName);

                //// Validate key is gone by listing keys
                //var keyList2 = sqlClient.ServerKeys.ListByServer(resourceGroup.Name, server.Name);
                //Assert.Equal(1, keyList2.Count());
            }
        }
    }
}